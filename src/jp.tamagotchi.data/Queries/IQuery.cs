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
        public virtual bool Sucessful =>(Errors?.Count ?? 0) != 0;
        public List<Exception> Errors { get; set; }

        public QueryResult AddError(Exception ex)
        {
            Errors.Add(ex);

            return this;
        }

    }

    public class DataQueryResult<TData> : QueryResult
    {
        public override bool Sucessful =>(Errors?.Count ?? 0) != 0 && Data != null;
        public TData Data { get; set; }
    }
}