﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    public static class ResourceIdentifierExtensions
    {
        private const string DatabaseAccounts = "databaseAccounts";
        private const string SqlDatabases = "sqlDatabases";
        private const string Containers = "containers";
        private const string StoredProcedures = "storedProcedures";
        private const string UserDefinedFunctions = "userDefinedFunctions";
        private const string Triggers = "triggers";

        public static string GetDatabaseAccountName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, DatabaseAccounts);
        }

        public static string GetSqlDatabaseName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, SqlDatabases);
        }

        public static string GetSqlContainerName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, Containers);
        }

        public static string GetSqlStoredProcedureName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, StoredProcedures);
        }

        public static string GetSqlUserDefinedFunctionName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, UserDefinedFunctions);
        }

        public static string GetSqlTriggerFunctionName(this ResourceIdentifier resourceId)
        {
            return GetChildResourceName(resourceId, Triggers);
        }

        private static string GetChildResourceName(this ResourceIdentifier resourceId, string resourceType)
        {
            var parentResource = resourceId.ParentResource.Split(new[] { '/' });

            for (int idx = 0; idx < parentResource.Length; idx++)
            {
                if (parentResource[idx].Equals(resourceType, StringComparison.OrdinalIgnoreCase))
                {
                    return parentResource[idx + 1];
                }
            }

            return null;
        }
    }
}