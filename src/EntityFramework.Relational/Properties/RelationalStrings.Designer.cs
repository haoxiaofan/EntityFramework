// <auto-generated />
namespace Microsoft.Data.Entity.Internal
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using JetBrains.Annotations;

    public static class RelationalStrings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("EntityFramework.Relational.RelationalStrings", typeof(RelationalStrings).GetTypeInfo().Assembly);

        /// <summary>
        /// Cannot create a ModificationFunction for an entity in state '{entityState}'.
        /// </summary>
        public static string ModificationFunctionInvalidEntityState([CanBeNull] object entityState)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ModificationFunctionInvalidEntityState", "entityState"), entityState);
        }

        /// <summary>
        /// Two entities cannot make conflicting updates to the same row.
        /// </summary>
        public static string ConflictingRowUpdates
        {
            get { return GetString("ConflictingRowUpdates"); }
        }

        /// <summary>
        /// Database operation expected to affect {expectedRows} row(s) but actually affected {actualRows} row(s). Data may have been modified or deleted since entities were loaded. See http://go.microsoft.com/fwlink/?LinkId=527962 for information on understanding and handling optimistic concurrency exceptions.
        /// </summary>
        public static string UpdateConcurrencyException([CanBeNull] object expectedRows, [CanBeNull] object actualRows)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UpdateConcurrencyException", "expectedRows", "actualRows"), expectedRows, actualRows);
        }

        /// <summary>
        /// Multiple relational database provider configurations found. A context can only be configured to use a single database provider.
        /// </summary>
        public static string MultipleProvidersConfigured
        {
            get { return GetString("MultipleProvidersConfigured"); }
        }

        /// <summary>
        /// No relational database providers are configured. Configure a database provider using OnConfiguring or by creating an ImmutableDbContextOptions with a database provider configured and passing it to the context.
        /// </summary>
        public static string NoProviderConfigured
        {
            get { return GetString("NoProviderConfigured"); }
        }

        /// <summary>
        /// Both an existing DbConnection and a connection string have been configured. When an existing DbConnection is used the connection string must be set on that connection.
        /// </summary>
        public static string ConnectionAndConnectionString
        {
            get { return GetString("ConnectionAndConnectionString"); }
        }

        /// <summary>
        /// A relational store has been configured without specifying either the DbConnection or connection string to use.
        /// </summary>
        public static string NoConnectionOrConnectionString
        {
            get { return GetString("NoConnectionOrConnectionString"); }
        }

        /// <summary>
        /// No mapping to a relational type can be found for the CLR type '{clrType}'
        /// </summary>
        public static string UnsupportedType([CanBeNull] object clrType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnsupportedType", "clrType"), clrType);
        }

        /// <summary>
        /// Relational-specific methods can only be used when the context is using a relational database provider.
        /// </summary>
        public static string RelationalNotInUse
        {
            get { return GetString("RelationalNotInUse"); }
        }

        /// <summary>
        /// An error occurred while updating the entries. See the inner exception for details.
        /// </summary>
        public static string UpdateStoreException
        {
            get { return GetString("UpdateStoreException"); }
        }

        /// <summary>
        /// The connection is already in a transaction and cannot participate in another transaction.
        /// </summary>
        public static string TransactionAlreadyStarted
        {
            get { return GetString("TransactionAlreadyStarted"); }
        }

        /// <summary>
        /// The connection does not have any active transactions.
        /// </summary>
        public static string NoActiveTransaction
        {
            get { return GetString("NoActiveTransaction"); }
        }

        /// <summary>
        /// The specified transaction is not associated with the current connection. Only transactions associated with the current connection may be used.
        /// </summary>
        public static string TransactionAssociatedWithDifferentConnection
        {
            get { return GetString("TransactionAssociatedWithDifferentConnection"); }
        }

        /// <summary>
        /// Opening connection '{connectionString}'.
        /// </summary>
        public static string RelationalLoggerOpeningConnection([CanBeNull] object connectionString)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RelationalLoggerOpeningConnection", "connectionString"), connectionString);
        }

        /// <summary>
        /// Closing connection '{connectionString}'.
        /// </summary>
        public static string RelationalLoggerClosingConnection([CanBeNull] object connectionString)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RelationalLoggerClosingConnection", "connectionString"), connectionString);
        }

        /// <summary>
        /// Beginning transaction with isolation level '{isolationLevel}'.
        /// </summary>
        public static string RelationalLoggerBeginningTransaction([CanBeNull] object isolationLevel)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RelationalLoggerBeginningTransaction", "isolationLevel"), isolationLevel);
        }

        /// <summary>
        /// Committing transaction.
        /// </summary>
        public static string RelationalLoggerCommittingTransaction
        {
            get { return GetString("RelationalLoggerCommittingTransaction"); }
        }

        /// <summary>
        /// Rolling back transaction.
        /// </summary>
        public static string RelationalLoggerRollingbackTransaction
        {
            get { return GetString("RelationalLoggerRollingbackTransaction"); }
        }

        /// <summary>
        /// Invalid type for sequence. Valid types are 'Int64' (the default), 'Int32', 'Int16', and 'Byte'.
        /// </summary>
        public static string BadSequenceType
        {
            get { return GetString("BadSequenceType"); }
        }

        /// <summary>
        /// Unable to deserialize sequence from model metadata. See inner exception for details.
        /// </summary>
        public static string BadSequenceString
        {
            get { return GetString("BadSequenceString"); }
        }

        /// <summary>
        /// The migration '{migrationName}' was not found.
        /// </summary>
        public static string MigrationNotFound([CanBeNull] object migrationName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MigrationNotFound", "migrationName"), migrationName);
        }

        /// <summary>
        /// The current migration SQL generator '{sqlGeneratorType}' is unable to generate SQL for operations of type '{operationType}'.
        /// </summary>
        public static string UnknownOperation([CanBeNull] object sqlGeneratorType, [CanBeNull] object operationType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnknownOperation", "sqlGeneratorType", "operationType"), sqlGeneratorType, operationType);
        }

        /// <summary>
        /// The specified CommandTimeout value is not valid. It must be a positive number.
        /// </summary>
        public static string InvalidCommandTimeout
        {
            get { return GetString("InvalidCommandTimeout"); }
        }

        /// <summary>
        /// The specified MaxBatchSize value is not valid. It must be a positive number.
        /// </summary>
        public static string InvalidMaxBatchSize
        {
            get { return GetString("InvalidMaxBatchSize"); }
        }

        /// <summary>
        /// Unable to materialize entity of type '{entityType}'. No discriminators were matched.
        /// </summary>
        public static string UnableToDiscriminate([CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToDiscriminate", "entityType"), entityType);
        }

        /// <summary>
        /// A discriminator property cannot be set for the entity type '{entityType}' because it is not the root of an inheritance hierarchy.
        /// </summary>
        public static string DiscriminatorPropertyMustBeOnRoot([CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DiscriminatorPropertyMustBeOnRoot", "entityType"), entityType);
        }

        /// <summary>
        /// Unable to set property '{property}' as a discriminator for entity type '{entityType}' because it is not a property of '{entityType}'.
        /// </summary>
        public static string DiscriminatorPropertyNotFound([CanBeNull] object property, [CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DiscriminatorPropertyNotFound", "property", "entityType"), property, entityType);
        }

        /// <summary>
        /// An ambient transaction has been detected. Connections opened by Entity Framework will not be enlisted in ambient transactions. To suppress this warning call SuppressAmbientTransactionWarning() when overriding DbContext.OnConfiguring.
        /// </summary>
        public static string AmbientTransaction
        {
            get { return GetString("AmbientTransaction"); }
        }

        /// <summary>
        /// Possible unintended use of method Equals(object) for arguments of different types: '{left}', '{right}'. This comparison will always return 'false'.
        /// </summary>
        public static string PossibleUnintendedUseOfEquals([CanBeNull] object left, [CanBeNull] object right)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("PossibleUnintendedUseOfEquals", "left", "right"), left, right);
        }

        /// <summary>
        /// The Include operation is not supported when calling a stored procedure.
        /// </summary>
        public static string StoredProcedureIncludeNotSupported
        {
            get { return GetString("StoredProcedureIncludeNotSupported"); }
        }

        /// <summary>
        /// Generating down script for migration '{migration}'.
        /// </summary>
        public static string GeneratingDown([CanBeNull] object migration)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("GeneratingDown", "migration"), migration);
        }

        /// <summary>
        /// Generating up script for migration '{migration}'.
        /// </summary>
        public static string GeneratingUp([CanBeNull] object migration)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("GeneratingUp", "migration"), migration);
        }

        /// <summary>
        /// Applying migration '{migration}'.
        /// </summary>
        public static string ApplyingMigration([CanBeNull] object migration)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ApplyingMigration", "migration"), migration);
        }

        /// <summary>
        /// Unapplying migration '{migration}'.
        /// </summary>
        public static string RevertingMigration([CanBeNull] object migration)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RevertingMigration", "migration"), migration);
        }

        /// <summary>
        /// Using database '{database}' on server '{dataSource}'.
        /// </summary>
        public static string UsingConnection([CanBeNull] object database, [CanBeNull] object dataSource)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UsingConnection", "database", "dataSource"), database, dataSource);
        }

        /// <summary>
        /// The required column '{column}' was not present in the results of a 'FromSql' operation.
        /// </summary>
        public static string FromSqlMissingColumn([CanBeNull] object column)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("FromSqlMissingColumn", "column"), column);
        }

        /// <summary>
        /// Cannot use table '{table}' in schema '{schema}' for entity '{entityType}' since it is being used for another entity.
        /// </summary>
        public static string DuplicateTableName([CanBeNull] object table, [CanBeNull] object schema, [CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DuplicateTableName", "table", "schema", "entityType"), table, schema, entityType);
        }

        /// <summary>
        /// GetCreateScript only handles operations in a single batch. For more advanced scenarios, override HistoryRepository.GetCreateScript in your provider.
        /// </summary>
        public static string InvalidCreateScript
        {
            get { return GetString("InvalidCreateScript"); }
        }

        /// <summary>
        /// Cannot configure the discriminator value for entity type '{entityType}' because it doesn't derive from '{rootEntityType}'.
        /// </summary>
        public static string DiscriminatorEntityTypeNotDerived([CanBeNull] object entityType, [CanBeNull] object rootEntityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DiscriminatorEntityTypeNotDerived", "entityType", "rootEntityType"), entityType, rootEntityType);
        }

        /// <summary>
        /// Cannot set discriminator value '{value}' for discriminator property '{discriminator}' because it is not assignable to property of type '{discriminatorType}'.
        /// </summary>
        public static string DiscriminitatorValueIncompatible([CanBeNull] object value, [CanBeNull] object discriminator, [CanBeNull] object discriminatorType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DiscriminitatorValueIncompatible", "value", "discriminator", "discriminatorType"), value, discriminator, discriminatorType);
        }

        /// <summary>
        /// Cannot set discriminator value for entity type '{entityType}' because the root entity type '{rootEntityType}' doesn't have a discriminator property set.
        /// </summary>
        public static string NoDiscriminatorForValue([CanBeNull] object entityType, [CanBeNull] object rootEntityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("NoDiscriminatorForValue", "entityType", "rootEntityType"), entityType, rootEntityType);
        }

        /// <summary>
        /// The entity type '{entityType}' is part of a hierarchy, but does not have a discriminator property configured.
        /// </summary>
        public static string NoDiscriminatorProperty([CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("NoDiscriminatorProperty", "entityType"), entityType);
        }

        /// <summary>
        /// The entity type '{entityType}' is part of a hierarchy, but does not have a discriminator value configured.
        /// </summary>
        public static string NoDiscriminatorValue([CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("NoDiscriminatorValue", "entityType"), entityType);
        }

        /// <summary>
        /// Unable to materialize an entity of type '{entityType}' because it has an null key value.
        /// </summary>
        public static string InvalidKeyValue([CanBeNull] object entityType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidKeyValue", "entityType"), entityType);
        }

        /// <summary>
        /// Unabled to compile the LINQ expression '{expression}' because it requires client evaluation, which is disabled. Either enable client evaluation or rewrite the query to not require client evaluation.
        /// </summary>
        public static string ClientEvalDisabled([CanBeNull] object expression)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ClientEvalDisabled", "expression"), expression);
        }

        /// <summary>
        /// The LINQ expression '{expression}' could not be translated and will be evaluated locally.
        /// </summary>
        public static string ClientEvalWarning([CanBeNull] object expression)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ClientEvalWarning", "expression"), expression);
        }

        /// <summary>
        /// SQL parameter value logging is enabled. As SQL parameter values may include sensitive application data, this mode should only be enabled during development.
        /// </summary>
        public static string ParameterLoggingEnabled
        {
            get { return GetString("ParameterLoggingEnabled"); }
        }

        /// <summary>
        /// Executed DbCommand ({elapsed}ms) [Parameters=[{parameters}], CommandType='{commandType}', CommandTimeout='{commandTimeout}']{newLine}{commandText}
        /// </summary>
        public static string RelationalLoggerExecutedCommand([CanBeNull] object elapsed, [CanBeNull] object parameters, [CanBeNull] object commandType, [CanBeNull] object commandTimeout, [CanBeNull] object newLine, [CanBeNull] object commandText)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RelationalLoggerExecutedCommand", "elapsed", "parameters", "commandType", "commandTimeout", "newLine", "commandText"), elapsed, parameters, commandType, commandTimeout, newLine, commandText);
        }

        /// <summary>
        /// Cannot use column name '{columnName}' in entity '{entityType}' for property '{property}' since it is being used for another property.
        /// </summary>
        public static string DuplicateColumnName([CanBeNull] object columnName, [CanBeNull] object entityType, [CanBeNull] object property)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("DuplicateColumnName", "columnName", "entityType", "property"), columnName, entityType, property);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
