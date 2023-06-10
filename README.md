# Text-Analytics-Service
This is a Text analyzer service built in .Net framework 6.0 which does the following task

For a given text it finds
- Number of characters (excluding spaces)
- Number of words
- Number of sentences
- Most frequent word and its frequency
- Longest word and its length

For given two seperate text it finds the similarity percentage of unique words among them

## Prerequisites
- .Net SDK 6.0 or higher
- IIS express 7.0 or higher(for windows)
- Latest stable  [.NET runtime installed](https://learn.microsoft.com/en-us/dotnet/core/install/linux) (for linux)
- Visual Studio 2022 (if you want to run on VS)

## Run The Project in Visual Studio
- Download the project from [here](https://github.com/sharif0rifat/Text-Analytics-Service)
- Click the run button or press F5

The application will start running and it open the default browser with url 'http://localhost:5103/swagger/index.html'. As there is swagger installed you can see 2 post method. By expanding any one of them and by clicking 'Try it Out' you can see a textbox where you can put give your POST value
for the first API you try with following example 

```http
  {
    "text": "The quick brown fox jumps over the lazy dog. The dog was
    not amused."
  }
```

For the second API you can try with this: 

```http
 {
    "text1": "The quick brown fox jumps over the lazy dog",
    "text2": "The dog was not amused"
 }
```