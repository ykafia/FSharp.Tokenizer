namespace FSharp.Tokenizers

module GPT2 =
    type GPT2Tokenizer = {
        number:int64
    }

module GPT2VocabFiles =
    
    let GPT2PretrainedFiles = [
        "vocab_files", dict[
            "gpt2","https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-vocab.json";
            "gpt2-medium","https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-medium-vocab.json";
        ];
        "merge_files", dict[
            "gpt2", "https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-merges.txt";
            "gpt2-medium", "https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-medium-merges.txt";
        ];
    ]

    let PretrainedPositionalEmbeddingSize = [
        "gpt2", 1024;
        "gpt2-medium",1024;
    ]

    let VocabFileNames = [
        "vocab_file", "vocab.json";
        "merges_file", "merges.txt";
    ]



