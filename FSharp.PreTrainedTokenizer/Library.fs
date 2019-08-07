namespace FSharp.PreTrainedTokenizer
open System.Collections.Generic
module BaseTokenizer = 
    let DictAdd (key:string) (value:string) (x:Dictionary<string,string>) =
        x.Add(key,value)
        x
    type PreTrainedTokenizer(vFileName:string,vUrl:string,mUrl:string,sizeInput:int) as this =
        member this.VocabFileName = vFileName
        member this.VocabUrl = vUrl
        member this.MergeUrl = mUrl
        member this.InputSize = sizeInput

        member this.SpecialTokens = 
                    new Dictionary<string,string>()
                    |> DictAdd "bos_token" ""
                    |> DictAdd "eos_token" ""
                    |> DictAdd "unk_token" ""
                    |> DictAdd "sep_token" ""
                    |> DictAdd "pad_token" "" 
                    |> DictAdd "cls_token" "" 
                    |> DictAdd "mask_token" ""
                    |> DictAdd "additional_special_tokens" ""

       
        member this.BOSToken = 
            if this.SpecialTokens.["bos_token"] = ""
                then printfn "Token Begining not set"
                else this.SpecialTokens.["bos_token"]
        member this.EOSToken = 
            if this.SpecialTokens.["eos_token"] = ""
                then printfn "Token End not set"
                else this.SpecialTokens.["eos_token"]
        member this.UNKToken = 
            if this.SpecialTokens.["unk_token"] = ""
                then printfn "Token UNK not set"
                else this.SpecialTokens.["unk_token"]
        member this.SEPToken = 
            if this.SpecialTokens.["sep_token"] = ""
                then printfn "Token SEP not set"
                else this.SpecialTokens.["sep_token"]
        member this.PADToken = 
            if this.SpecialTokens.["pad_token"] = ""
            then printfn "Token PAD not set"
            else this.SpecialTokens.["pad_token"]
        member this.CLSToken = 
            if this.SpecialTokens.["cls_token"] = ""
            then printfn "Token CLS not set"
            else this.SpecialTokens.["cls_token"]
        member this.MaskToken = 
            if this.SpecialTokens.["mask_token"] = ""
                then printfn "Token Mask not set"
                else this.SpecialTokens.["mask_token"]
        member this.AddToken = 
            if this.SpecialTokens.["additional_special_tokens"] = ""
                then printfn "Token Special not set"
                else this.SpecialTokens.["additional_special_tokens"]
module Say =
    let hello name =
        printfn "Hello %s" name
