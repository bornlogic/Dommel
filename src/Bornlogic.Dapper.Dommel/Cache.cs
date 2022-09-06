using System;
using System.Reflection;

namespace Dommel
{
    internal enum QueryCacheType
    {
        Get,
        GetByMultipleIds,
        GetAll,
        Project,
        ProjectAll,
        Count,
        Insert,
        Update,
        Delete,
        DeleteAll,
        Any,
    }

    internal readonly struct QueryCacheKey : IEquatable<QueryCacheKey>
    {
        public QueryCacheKey(QueryCacheType cacheType, ISqlBuilder sqlBuilder, MemberInfo memberInfo, string tableName, string extraData = null)
        {
            SqlBuilderType = sqlBuilder.GetType();
            CacheType = cacheType;
            MemberInfo = memberInfo;
            TableName = tableName;
            ExtraData = extraData;
        }

        public QueryCacheType CacheType { get; }

        public Type SqlBuilderType { get; }

        public MemberInfo MemberInfo { get; }

        /// <summary>
        /// Table name with schema
        /// </summary>
        public string TableName { get; }
        public string ExtraData { get; }

        public bool Equals(QueryCacheKey other) =>
            CacheType == other.CacheType &&
                SqlBuilderType == other.SqlBuilderType &&
                MemberInfo == other.MemberInfo &&
                TableName == other.TableName &&
                ExtraData == other.ExtraData;
    }
}
