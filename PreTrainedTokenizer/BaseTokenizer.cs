using System;
using System.Collections.Generic;
using Math;

namespace PreTrainedTokenizer
{
    public class BaseTokenizer
    {
        public string VocabFileName{get;set;}
        public string VocabUrl{get;set;}
        public string MergeURL{get;set;}
        public string InputSize{get;set;}
        public string EOSToken{get;set;}
        public string BOSToken{get;set;}
        public string PADToken{get;set;}
        public string MaskToken{get;set;}
        public string SEPToken{get;set;}
        
        public List<string> ATokens{get;set;}

        public int MaxLength {get;set;}

        public BaseTokenizer(int maxlen = Math.Pow(10,12), Dictionary<string,string> values = null)
        {
            this.FillEmptyTokens();
            this.MaxLength = maxlen;
            if(values)
            {
                foreach(KeyValuePair<string,string> entry in values)
                {
                    
                }
            }
        }

        public void FillDictEmptyString()
        {
            this.SpecialTokens = new Dictionary<string, string>();
            this.SpecialTokens.Add("bos_token","");
            this.SpecialTokens.Add("eos_token","");
            this.SpecialTokens.Add("cls_token","");
            this.SpecialTokens.Add("mask_token","");
            this.SpecialTokens.Add("sep_token","");
            this.SpecialTokens.Add("pad_token","");
            this.SpecialTokens.Add("unk_token","");
            this.ATokens = new List<string>();
        }
        public string BOSToken()
        {
            if(SpecialTokens["bos_token"] =="")
            {
                Console.WriteLine("BOS Token not initialized");
            }
            return SpecialTokens["bos_token"];
        }
        public string EOSToken()
        {
            if(SpecialTokens["eos_token"] =="")
            {
                Console.WriteLine("EOS Token not initialized");
            }
            return SpecialTokens["eos_token"];
        }
        public string UNKToken()
        {
            if(SpecialTokens["unk_token"] =="")
            {
                Console.WriteLine("UNK Token not initialized");
            }
            return SpecialTokens["unk_token"];
        }
        public string SEPToken()
        {
            if(SpecialTokens["sep_token"] =="")
            {
                Console.WriteLine("SEP Token not initialized");
            }
            return SpecialTokens["sep_token"];
        }
        public string PADToken()
        {
            if(SpecialTokens["pad_token"] =="")
            {
                Console.WriteLine("PAD Token not initialized");
            }
            return SpecialTokens["pad_token"];
        }
        public string CLSToken()
        {
            if(SpecialTokens["cls_token"] =="")
            {
                Console.WriteLine("CLS Token not initialized");
            }
            return SpecialTokens["cls_token"];
        }
        public string MaskToken()
        {
            if(SpecialTokens["mask_token"] =="")
            {
                Console.WriteLine("MASK Token not initialized");
            }
            return SpecialTokens["mask_token"];
        }
        public List<string> AdditionalTokens()
        {
            if(this.ATokens.Count==0)
            {
                Console.WriteLine("No additional tokens");
            }
            return this.ATokens;
        }
    }
}
