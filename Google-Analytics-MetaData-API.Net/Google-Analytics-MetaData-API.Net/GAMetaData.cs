using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Analytics.v3;

namespace Google_Analytics_MetaData_API.Net
{
    class GAMetaData
    {

        /// <summary>
        /// retrieves a list of the Google Analtyics accounts for the curently autenticated user.
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <returns></returns>
        public static Columns MetaListAll(AnalyticsService service)
        {

            MetadataResource.ColumnsResource.ListRequest request = service.Metadata.Columns.List("ga");
            Columns result = request.Execute();
            return result;
        }
        public static List<string> getGroups(AnalyticsService service)
        {

            MetadataResource.ColumnsResource.ListRequest request = service.Metadata.Columns.List("ga");
            Columns result = request.Execute();

            return result.Items.Select(a => a.Attributes["group"]).Distinct().ToList();
        }


        public static List<Column> getDimensions(AnalyticsService service)
        {
            MetadataResource.ColumnsResource.ListRequest request = service.Metadata.Columns.List("ga");
            Columns result = request.Execute();
            return result.Items.Where(a => a.Attributes["type"] == "DIMENSION" ).ToList();
        }

        public static List<Column> getMetrics(AnalyticsService service)
        {
            MetadataResource.ColumnsResource.ListRequest request = service.Metadata.Columns.List("ga");
            Columns result = request.Execute();
            return result.Items.Where(a => a.Attributes["type"] == "METRIC").ToList();
        }
    }
}
