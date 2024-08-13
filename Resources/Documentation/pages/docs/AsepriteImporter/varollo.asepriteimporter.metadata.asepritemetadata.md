[`< Back`](./)

---

# AsepriteMetaData

Namespace: Varollo.AsepriteImporter.MetaData

Structure containing [AsepriteMetaData](varollo.asepriteimporter.metadata.asepritemetadata) of a [AsepriteSheet](varollo.asepriteimporter.asepritesheet).

```csharp
public struct AsepriteMetaData
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [AsepriteMetaData](varollo.asepriteimporter.metadata.asepritemetadata)

## Properties

### **App**

URI to Aseprite's official website.
 <br><br>
 Represents property
 "app"
 on sprite sheet's JSON data.

```csharp
public Uri App { get; internal set; }
```

#### Property Value

Uri<br>

### **Version**

Version of Aseprite used to generate the sprite sheet.
 <br><br>
 Represents property
 "version"
 on sprite sheet's JSON data.

```csharp
public string Version { get; internal set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Image**

Path to the texture file related to the sprite sheet.
 <br><br>
 Represents property
 "image"
 on sprite sheet's JSON data.

```csharp
public string Image { get; internal set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Format**

Color format on Aseprite.
 <br><br>
 Represents property
 "format"
 on sprite sheet's JSON data.

```csharp
public string Format { get; internal set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Size**

Bidimensional vector corresponding to the pixelsize of the full sprite sheet texture.
 <br><br>
 Represents property
 "size"
 on sprite sheet's JSON data.

```csharp
public Point Size { get; internal set; }
```

#### Property Value

Point<br>

### **Scale**

Scale of sprite sheet in aseprite.
 <br><br>
 Represents property
 "size"
 on sprite sheet's JSON data.

```csharp
public double Scale { get; internal set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Tags**

Tagmeta data of sprite sheet.
 <br><br>
 Represents property
 "frameTags"
 on sprite sheet's JSON data.

```csharp
public AsepriteTagData[] Tags { get; internal set; }
```

#### Property Value

[AsepriteTagData[]](varollo.asepriteimporter.metadata.asepritetagdata)<br>

### **Layers**

Layermeta data of sprite sheet.
 <br><br>
 Represents property
 "layer"
 on sprite sheet's JSON data.

```csharp
public AsepriteLayerData[] Layers { get; internal set; }
```

#### Property Value

[AsepriteLayerData[]](varollo.asepriteimporter.metadata.asepritelayerdata)<br>

---

[`< Back`](./)
