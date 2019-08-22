using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using Refit;

namespace PreTrainedTokenizer
{
    public abstract class BaseTokenizer
    {
        public string VocabFileName{get;set;}
        public string VocabUrl{get;set;}
        public string MergeFileName{get;set;}
        public string MergeURL{get;set;}
        public string InputSize{get;set;}
        public string EOSToken{get;set;}
        public string BOSToken{get;set;}
        public string PADToken{get;set;}
        public string MaskToken{get;set;}
        public string SEPToken{get;set;}
        public Dictionary<string,int> Encoder{get;set;}
        //TODO : to create the decoder just fill the Encoder and do a Decoder = Encoder.Reverse()
        public Dictionary<int,string> Decoder{get;set;}
        
        public List<string> ATokens{get;set;}

        public long MaxLength {get;set;}

        public BaseTokenizer(long maxlen = 1000000000000, Dictionary<string,string> values = null, List<string> additionalTokens = null)
        {
            this.EOSToken = "";
            this.BOSToken = "";
            this.SEPToken = "";
            this.PADToken = "";
            this.MaskToken = "";
            this.ATokens = new List<string>();
            this.MaxLength = maxlen;

            if(values != null)
            {
                foreach(KeyValuePair<string,string> entry in values)
                {
                    switch(entry.Key)
                    {
                        case "EOS" :
                            this.EOSToken = entry.Value;
                            break;
                        case "BOS" :
                            this.BOSToken = entry.Value;
                            break;
                        case "SEP" :
                            this.SEPToken = entry.Value;
                            break;
                        case "PAD" :
                            this.PADToken = entry.Value;
                            break;
                        case "Mask" :
                            this.MaskToken = entry.Value;
                            break;
                        default :
                            break;
                    }
                }
            }
            if(additionalTokens!= null)
            {
                this.ATokens.AddRange(additionalTokens);
            }
        }
        public void AddAdditionalTokens(List<string> tokens)
        {
            this.ATokens.AddRange(tokens);
        }
        public void AddAdditionalToken(string token)
        {
            this.ATokens.Add(token);
        }

        public abstract void LoadModel();
        public abstract void SaveModel();

        public abstract void SaveVocabulary();
        public virtual List<string> Decode(int[] encoded)
        {
            return encoded.Select( e => Decoder[e] ).ToList();
        }
        public virtual List<string> ParallelDecode(int[] encoded)
        {
            return encoded.AsParallel().Select( e => Decoder[e] ).ToList();
        }
        
        public virtual List<int> Encode(string[] text)
        {
            return text.Select( e => Encoder[e] ).ToList();
        }
        public virtual List<int> ParallelEncode(string[] text)
        {
            return text.AsParallel().Select( e => Encoder[e] ).ToList();
        }
        public async virtual void LoadVocabularyFromUrl(string url)
        {
            var vocabGetter = RestService.For<IJsonRequests>(url);
            this.Decoder = await vocabGetter.GetVocab();
            this.Encoder = this.Decoder.Reverse().ToDictionary(x=>x.Value,x=>x.Key);


        }
        
        
    }
}
