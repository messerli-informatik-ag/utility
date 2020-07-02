# Changelog

## 0.1.0
- Initial release

## 0.1.1
- Fix type checks

## 0.2.0
- Update to netstandard2.1

## 0.2.1
- Update nuget metadata

## 0.2.2
- Add support for .NET Standard 2.0.
- Remove misleading nullability attributes from `FirstOrDefaultAsync`.

## 0.2.3
- Add `ForEachAsync` extension for `IEnumerable`

## Unreleased
- The extension method `ForEach` for `IEnumerable` has been removed. Use the method of the same name from [Funcky](https://github.com/messerli-informatik-ag/funcky/blob/master/Funcky/Extensions/EnumerableExtensions.cs) instead (The method was called `Each` in versions before 2.0.0). 
