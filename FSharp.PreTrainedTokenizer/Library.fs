namespace FSharp.PreTrainedTokenizer
open System.Collections.Generic

module BaseTokenizer = 

    let DictAdd (key:string) (value:string) (x:Dictionary<string,string>) : Dictionary<string,string> =
        x.Add(key,value)
        x


    type PreTrainedTokenizer(vFileName:string,vUrl:string,mUrl:string,sizeInput:int) =
        member this.VocabFileName = vFileName
        member this.VocabUrl = vUrl
        member this.MergeUrl = mUrl
        member this.InputSize = sizeInput

        member this.SpecialTokens = 
                    let dict = new Dictionary<string,string>()
                    dict
                        |> DictAdd "bos_token" ""
                        |> DictAdd "eos_token" ""
                        |> DictAdd "unk_token" ""
                        |> DictAdd "sep_token" ""
                        |> DictAdd "pad_token" "" 
                        |> DictAdd "cls_token" "" 
                        |> DictAdd "mask_token" ""
                        |> DictAdd "additional_special_tokens" ""

       
        member this.BOSToken() = 
            this.SpecialTokens.["bos_token"]

        member this.EOSToken() = 
            this.SpecialTokens.["eos_token"]

        member this.UNKToken() = 
            this.SpecialTokens.["unk_token"] 

        member this.SEPToken() = 
            this.SpecialTokens.["sep_token"] 
            
        member this.PADToken() = 
            this.SpecialTokens.["pad_token"]
            
        member this.CLSToken() = 
            this.SpecialTokens.["cls_token"]
            
        member this.MaskToken() = 
            this.SpecialTokens.["mask_token"] 
            
        member this.AddToken() = 
            this.SpecialTokens.["additional_special_tokens"]

        
            
