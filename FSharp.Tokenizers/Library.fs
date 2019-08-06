namespace FSharp.Tokenizers

module Tokenizers =
    
    type PretrainedFiles = {
        VocabFiles:File;
        MergeFiles:File;
    }
    type File = {
        Name: string;
        Url : string;
    }
    let GPT2PretrainedFiles = dict[
        "vocab_files", dict[
            "gpt2","https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-vocab.json";
            "gpt2-medium","https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-medium-vocab.json";
        ];
        "merge_files", dict[
            "gpt2", "https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-merges.txt";
            "gpt2-medium", "https://s3.amazonaws.com/models.huggingface.co/bert/gpt2-medium-merges.txt";
        ];
    ]

    PretrainedPositionalEmbeddingSize = dict[
        "gpt2", 1024;
        "gpt2-medium",1024;
    ]

    VocabFileNames = dict[
        "vocab_file": "vocab.json",
        "merges_file": "merges.txt",
    ]



