[`< Back`](./)

---

# AsepriteDataLoader

Namespace: Varollo.AsepriteImporter

Loads JSON data generated from a Aseprite Sprite Sheet

```csharp
public static class AsepriteDataLoader
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AsepriteDataLoader](varollo.asepriteimporter.asepritedataloader)

## Methods

### **ParseJsonData(String)**

Parses JSON data into a a [AsepriteSheet](varollo.asepriteimporter.asepritesheet) object.

```csharp
public static AsepriteSheet ParseJsonData(string json)
```

#### Parameters

`json` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
String containing JSON data to be parsed into a [AsepriteSheet](varollo.asepriteimporter.asepritesheet) object.

#### Returns

[AsepriteSheet](varollo.asepriteimporter.asepritesheet)<br>

### **LoadJsonData(String)**

Loads a JSON file at `path` and parses it into a [AsepriteSheet](varollo.asepriteimporter.asepritesheet) object.

```csharp
public static AsepriteSheet LoadJsonData(string path)
```

#### Parameters

`path` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
String containing the path to the JSON file generated with a Aseprite Sprite Sheet.

#### Returns

[AsepriteSheet](varollo.asepriteimporter.asepritesheet)<br>
Parsed JSON data.

---

[`< Back`](./)
