﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CoreSports.Services.Contracts;
using CoreSports.Services.Models;
using Models;

namespace CoreSports.Services
{
    public class XmlMappingService : IMappingService
    {
        public EventCommand MapToEvents(Stream documentStream)
        {
            XDocument document = XDocument.Load(documentStream);

            var isCreateOperation = document.Descendants("UpcomingEvents").Count() != 0;
            var isUpdateOperation = document.Descendants("UpdateEvents").Count() != 0;

            var newCommand = new EventCommand();
            var tenisEvents = this.MapEvents(document.Descendants("TennisEvent"), EventType.Tenis);
            var footballEvents = this.MapEvents(document.Descendants("FootballEvent"), EventType.Football);
            var result = new List<Event>();
            result.AddRange(tenisEvents);
            result.AddRange(footballEvents);

            if (isUpdateOperation)
            {
                newCommand.Type = CommandType.Update;
            }

            if (isCreateOperation)
            {
                newCommand.Type = CommandType.Create;
            }

            newCommand.Models = result;
            return newCommand;
        }

        private IList<Event> MapEvents(IEnumerable<XElement> elements, EventType eventType)
        {
            return elements.Select(item =>
            {
                var eventId = item.Attribute("ID")?.Value.ToString();
                var eventTime = DateTime.Parse(item.Attribute("EventTime")?.Value.ToString());
                var home = item.Attribute("Home")?.Value.ToString();
                var away = item.Attribute("Away")?.Value.ToString();
                var newEvent = new Event
                {
                    InternalId = int.Parse(eventId),
                    Time = eventTime,
                    Away = away,
                    Home = home,
                    Type = eventType,
                    Markets = this.MapMarkets(item.Descendants("Market"))
                };

                return newEvent;
            }).ToList();
        }

        private IList<Market> MapMarkets(IEnumerable<XElement> elements)
        {
            return elements.Select(marketItem =>
            {
                var marketId = int.Parse(marketItem.Attribute("ID")?.Value.ToString());
                var marketNumber = int.Parse(marketItem.Attribute("Number")?.Value.ToString());
                var marketName = marketItem.Attribute("Name")?.Value.ToString();
                var marketStatus = marketItem.Attribute("Status")?.Value.ToString();

                var newMarket = new Market
                {
                    InternalId = marketId,
                    Number = marketNumber,
                    Name = marketName,
                    Selections = this.MapSelections(marketItem.Descendants("Selection")),
                    Status = marketStatus == null ? MarketStatus.Open : MarketStatus.Close
                };

                return newMarket;
            }).ToList();
        }

        private IList<Selection> MapSelections(IEnumerable<XElement> elements)
        {
            return elements.Select(selectionItem =>
            {
                var selectionId = int.Parse(selectionItem.Attribute("ID")?.Value.ToString());
                var selectionNumber = int.Parse(selectionItem.Attribute("Number")?.Value.ToString());
                var selectionDescription = selectionItem.Attribute("Description")?.Value.ToString();
                var selectionOdds = decimal.Parse(selectionItem.Attribute("OddsDecimal")?.Value.ToString());
                var participantType = this.MapParticipantType(selectionItem.Attribute("Participant")?.Value.ToString());

                var newSelection = new Selection
                {
                    InternalId = selectionId,
                    Number = selectionNumber,
                    Description = selectionDescription,
                    Odds = selectionOdds,
                    ParticipantType = participantType
                };

                return newSelection;
            }).ToList();
        }

        public ParticipantType MapParticipantType(string rawType)
        {
            if (rawType == "HOME")
            {
                return ParticipantType.Home;
            }

            if (rawType == "AWAY")
            {
                return ParticipantType.Away;
            }

            if (rawType == "DRAW")
            {
                return ParticipantType.Draw;
            }

            return ParticipantType.None;
        }
    }
}
