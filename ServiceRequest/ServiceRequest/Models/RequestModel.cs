using Newtonsoft.Json;
using System;

namespace ServiceRequest.Models
{
    public class RequestModel
    {
            [JsonProperty("INCIDENT_ID")]
            public string INCIDENTID { get; set; }

            [JsonProperty("INCIDENT_NUMBER")]
            public string INCIDENTNUMBER { get; set; }

            [JsonProperty("INCIDENT_TYPE_ID")]
            public int INCIDENTTYPEID { get; set; }

            [JsonProperty("INCIDENT_STATUS_ID")]
            public int INCIDENTSTATUSID { get; set; }

            [JsonProperty("INCIDENT_SEVERITY_ID")]
            public int INCIDENTSEVERITYID { get; set; }

            [JsonProperty("SR_OWNER_ID")]
            public string SROWNERID { get; set; }

            [JsonProperty("SUMMARY")]
            public string SUMMARY { get; set; }

            [JsonProperty("CUSTOMER_ID")]
            public int CUSTOMERID { get; set; }

            [JsonProperty("INVENTORY_ITEM_ID")]
            public string INVENTORYITEMID { get; set; }

            [JsonProperty("CREATION_DATE")]
            public DateTime CREATIONDATE { get; set; }

            [JsonProperty("LAST_UPDATE_DATE")]
            public string LASTUPDATEDATE { get; set; }

            [JsonProperty("ORGANIZATION_ID")]
            public int ORGANIZATIONID { get; set; }

            [JsonProperty("INVENTORY_ORG_ID")]
            public string INVENTORYORGID { get; set; }
        }
}
