using System;
using System.Data.SqlClient;
using System.Xml.Serialization.Advanced;
using Snackboxx.Core;

namespace Snackboxx.DataBaseSchemaUpdates
{
    public abstract class SchemaUpdater
    {
        protected SchemaUpdater(DBConnection connection, Action<string> log)
        {
            var updateName = GetType().Name;
            using (var existingEntries = connection.GetResult($"Select * From T_DatabaseUpdates WHERE UpdateName = '{updateName}'"))
            {
                if (existingEntries.Read())
                    return;
            }
            log("Updating database: " + updateName);
            var transactionStarted = false;
            try
            {
                connection.Execute("BEGIN TRANSACTION");
                transactionStarted = true;
                connection.Execute($"Insert Into T_DatabaseUpdates VALUES ('{updateName}')");
                // ReSharper disable once VirtualMemberCallInConstructor
                ExecuteUpdate(connection);
                connection.Execute("COMMIT TRANSACTION");
                transactionStarted = false;
                log("Update Complete");
            }
            catch (Exception e)
            {
                if (transactionStarted)
                    connection.Execute("ROLLBACK TRANSACTION");
                log("Unable to Update Database");
                log(e.Message);
            }
        }

        protected abstract void ExecuteUpdate(DBConnection connection);
    }
}