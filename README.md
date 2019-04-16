# CombineObjectExpressionsTest
Test project on how to combine object expressions

Code for my [StackOverFlowQuestion](https://stackoverflow.com/questions/55440167/how-to-merge-object-expressions?noredirect=1#comment97597118_55440167) on how to combine two Expressions of object func :-)

I also filed an issue at [Atomapper](https://github.com/AutoMapper/AutoMapper/issues/3018#issuecomment-478276913) that prompted the SO question.


The reason I was doing this was to control what [related data](https://docs.microsoft.com/en-us/ef/core/querying/related-data?fbclid=IwAR0bWnQ_nHyVxVVAc8vE7JYZmaQJ34i52AS0etPCXGAaYNTy67yA6uWJZIE) was loaded in my RazorPage (web layer) and getting that information down through my ServiceLayer to the RepositoryLayer where my Entity Framework is.

This then ["Expression chaining"](http://stevesspace.com/2016/06/chaining-expressions-in-c/) looks promising.
