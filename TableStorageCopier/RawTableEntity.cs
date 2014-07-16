using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorageCopier
{
    public class RawTableEntity : ITableEntity
    {
        public string ETag { get; set; }
        public string PartitionKey { get; set; }
        public IDictionary<string, EntityProperty> Properties { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            Properties = properties;
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            return Properties;
        }
    }
}