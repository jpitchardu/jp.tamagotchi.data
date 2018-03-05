using System;
using System.Collections.Generic;

namespace jp.tamagotchi.data.Queries
{
    public interface IQuery<TPayload, TResult> where TResult : QueryResult
    {
        TResult Query(TPayload payload);
    }

    public class QueryResult
    {
        public List<Exception> _errors;
        public virtual bool Sucessful => Errors.Count == 0;
        public List<Exception> Errors { get => _errors ?? (_errors = new List<Exception>()); }

        public QueryResult AddError(Exception ex)
        {
            Errors.Add(ex);

            return this;
        }

    }

    public class DataQueryResult<TData> : QueryResult
    {
        public override bool Sucessful => Errors.Count == 0 && Data != null;
        public TData Data { get; set; }
    }
}