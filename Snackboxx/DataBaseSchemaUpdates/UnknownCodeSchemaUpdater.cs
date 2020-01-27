using System;
using Snackboxx.Core;

namespace Snackboxx.DataBaseSchemaUpdates
{
    public class UnknownCodeSchemaUpdater : SchemaUpdater
    {
        public UnknownCodeSchemaUpdater(DBConnection connection, Action<string> log) : base(connection, log)
        {
        }

        protected override void ExecuteUpdate(DBConnection connection)
        {
            connection.Execute(@"
            Alter Table T_User
            Add BetragsLimit decimal(5,2) DEFAULT 10;
");
            connection.Execute(@"
            -- noinspection SqlWithoutWhere
            Update T_User
            Set BetragsLimit = 10; 
            
            Create Table T_UnknownCodes(
  Time datetime,
  Code int,
  UnknownCodeID int)");
        }
    }
}