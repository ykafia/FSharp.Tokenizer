using System;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PreTrainedTokenizer
{
    public interface IJsonRequests
    {
        [Get("")]
        Task<Dictionary<int,string>> GetVocab();
        [Get("")]
        Task<Dictionary<int,string>> GetMerge();
    }


}