﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.DynamicEventsInformation.Details;
using GW2DotNET.V1.Core.DynamicEventsInformation.Names;
using GW2DotNET.V1.Core.DynamicEventsInformation.Status;
using GW2DotNET.V1.Core.MapsInformation.Names;
using GW2DotNET.V1.Core.WorldsInformation.Names;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.RestSharp;

namespace GW2DotNET.V1.DynamicEvents
{
    /// <summary>The data provider.</summary>
    public class DataProvider : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The event list cache file name.</summary>
        private readonly string eventListCacheFileName;

        /// <summary>Backing field for the event list, so we can replace values.</summary>
        private Lazy<DynamicEventCollection> eventList;

        /// <summary>Caching field for the event names. Lazy initialized.</summary>
        private Lazy<DynamicEventNameCollection> lazyEventNames;

        /// <summary>Caching field for the map names. Lazy initialized.</summary>
        private Lazy<MapNameCollection> lazyMapNames;

        /// <summary>Caching field for the world names. Lazy initialized.</summary>
        private Lazy<WorldNameCollection> lazyWorldNames;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public DataProvider(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The api manager.</param>
        /// <param name="bypassCaching">The bypass caching.</param>
        public DataProvider(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            BypassCache = bypassCaching;
            eventListCacheFileName = string.Format("{0}\\Cache\\EventCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            InitializeLazy();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the events.</summary>
        public DynamicEventCollection EventList
        {
            get
            {
                return eventList.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            var eventCache = new GameCache<DynamicEventCollection>
                             {
                                 Build = dataManager.Build,
                                 CacheData = eventList.Value
                             };

            WriteDataToDisk(eventListCacheFileName, eventCache);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Clears the cache.</summary>
        public override void ClearCache()
        {
            lazyEventNames = new Lazy<DynamicEventNameCollection>(GetEventNames);
            lazyMapNames = new Lazy<MapNameCollection>(GetMapNames);
            lazyWorldNames = new Lazy<WorldNameCollection>(GetWorldNames);

            eventList = new Lazy<DynamicEventCollection>();
        }

        /// <summary>Gets a list of all events from the server.</summary>
        /// <param name="worldId">The id of the world where the events are on.</param>
        /// <param name="mapId">The id of the map where all events are from.</param>
        /// <param name="eventId"></param>
        /// <returns>A <see cref="IEnumerable{DynamicEvent}">collection</see> of events.</returns>
        public IEnumerable<DynamicEvent> GetEventList(int? worldId = null, int? mapId = null, Guid? eventId = null)
        {
            var serviceClient = ServiceClient.Create();

            var request = new DynamicEventStatusRequest(worldId, mapId, eventId);

            var response = request.GetResponse(serviceClient);

            var events = response.EnsureSuccessStatusCode().Deserialize().Events;

            if (!BypassCache)
            {
                eventList.Value.AddRange(events);
            }

            return events;
        }

        /// <summary>Asynchronously gets a list of all events from the server.</summary>
        /// <param name="worldId">The id of the world where the events are on.</param>
        /// <param name="mapId">The id of the map where all events are from.</param>
        /// <param name="eventId"></param>
        /// <returns>A <see cref="IEnumerable{DynamicEvent}">collection</see> of events.</returns>
        public async Task<IEnumerable<DynamicEvent>> GetEventListAsync(int? worldId = null, int? mapId = null, Guid? eventId = null)
        {
            var serviceClient = ServiceClient.Create();

            var request = new DynamicEventStatusRequest(worldId, mapId, eventId);

            var response = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);

            var events = response.EnsureSuccessStatusCode().Deserialize().Events;

            if (!BypassCache)
            {
                eventList.Value.AddRange(events);
            }

            return events;
        }

        /// <summary>Gets the details for a particular event.</summary>
        /// <param name="dynamicEvent">The game event to get the details.</param>
        /// <returns>A <see cref="DynamicEvent"/> with all details.</returns>
        public DynamicEventDetails GetEventDetails(DynamicEvent dynamicEvent)
        {
            var serviceClient = ServiceClient.Create();

            var request = new DynamicEventDetailsRequest(dynamicEvent.EventId); // TODO: CultureInfo parameter

            var response = request.GetResponse(serviceClient);

            var dynamicEventDetails = response.EnsureSuccessStatusCode().Deserialize().EventDetails[dynamicEvent.EventId];

            return dynamicEventDetails;
        }

        /// <summary>Gets the details for a particular event asynchronously.</summary>
        /// <param name="dynamicEvent">The game event to get the details.</param>
        /// <returns>The <see cref="Task{DynamicEvent}"/> with all details..</returns>
        public async Task<DynamicEventDetails> GetEventDetailsAsync(DynamicEvent dynamicEvent)
        {
            var serviceClient = ServiceClient.Create();

            var request = new DynamicEventDetailsRequest(dynamicEvent.EventId); // TODO: CultureInfo parameter

            var response = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);

            var dynamicEventDetails = response.EnsureSuccessStatusCode().Deserialize().EventDetails[dynamicEvent.EventId];

            return dynamicEventDetails;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the world names from the server.</summary>
        /// <returns>An <see cref="IEnumerable{WorldName}"/> containing all world names.</returns>
        private WorldNameCollection GetWorldNames()
        {
            var serviceClient = ServiceClient.Create();

            var request = new WorldNamesRequest(); // TODO: CultureInfo parameter

            var response = request.GetResponse(serviceClient);

            var names = response.EnsureSuccessStatusCode().Deserialize();

            return names;
        }

        /// <summary>Gets the map names from the server.</summary>
        /// <returns>An <see cref="IEnumerable{MapName}"/> containing all map names.</returns>
        private MapNameCollection GetMapNames()
        {
            var serviceClient = ServiceClient.Create();

            var request = new MapNamesRequest(); // TODO: CultureInfo parameter

            var response = request.GetResponse(serviceClient);

            var names = response.EnsureSuccessStatusCode().Deserialize();

            return names;
        }

        /// <summary>Gets the event names from the server.</summary>
        /// <returns>An <see cref="IEnumerable{DynamicEventName}"/> containing all event names.</returns>
        private DynamicEventNameCollection GetEventNames()
        {
            var serviceClient = ServiceClient.Create();

            var request = new DynamicEventNamesRequest(); // TODO: CultureInfo parameter

            var response = request.GetResponse(serviceClient);

            var names = response.EnsureSuccessStatusCode().Deserialize();

            return names;
        }

        /// <summary>Initializes the lazy fields.</summary>
        private void InitializeLazy()
        {
            lazyEventNames = new Lazy<DynamicEventNameCollection>(GetEventNames);
            lazyMapNames = new Lazy<MapNameCollection>(GetMapNames);
            lazyWorldNames = new Lazy<WorldNameCollection>(GetWorldNames);

            int build;

            eventList = !BypassCache ? new Lazy<DynamicEventCollection>(() => ReadCacheFromDisk<DynamicEventCollection>(eventListCacheFileName, out build)) : new Lazy<DynamicEventCollection>();
        }
    }
}