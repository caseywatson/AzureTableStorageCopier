using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorageCopier
{
    internal class Program
    {
        private const string DestinationStorageConnectionString = "";
        private const string DestinationTableName = "";
        private const string SourceStorageConnectionString = "";
        private const string SourceTableName = "";

        private static void Main(string[] args)
        {
            var sourceCloudStorageAccount = CloudStorageAccount.Parse(SourceStorageConnectionString);
            var destinationCloudStorageAccount = CloudStorageAccount.Parse(DestinationStorageConnectionString);

            var sourceTableStorageClient = sourceCloudStorageAccount.CreateCloudTableClient();
            var destinationTableStorageClient = destinationCloudStorageAccount.CreateCloudTableClient();

            var sourceTable = sourceTableStorageClient.GetTableReference(SourceTableName);
            var destinationTable = destinationTableStorageClient.GetTableReference(DestinationTableName);

            destinationTable.CreateIfNotExists();

            var tableQuery = new TableQuery<RawTableEntity>();

            foreach (var entity in sourceTable.ExecuteQuery(tableQuery))
            {
                var insertOp = TableOperation.Insert(entity);
                destinationTable.Execute(insertOp);
            }
        }
    }
}