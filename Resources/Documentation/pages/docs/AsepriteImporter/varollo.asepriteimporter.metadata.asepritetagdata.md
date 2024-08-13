[`< Back`](./)

---

# AsepriteTagData

Namespace: Varollo.AsepriteImporter.MetaData

Structure containing [AsepriteMetaData](varollo.asepriteimporter.metadata.asepritemetadata) from a tag on a [AsepriteSheet](varollo.asepriteimporter.asepritesheet).

```csharp
public struct AsepriteTagData
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [AsepriteTagData](varollo.asepriteimporter.metadata.asepritetagdata)

## Properties

### **Name**

Name of the tag in Aseprite, used to group frames of the same animation.
 <br><br>
 Represents property `"name"` on [AsepriteMetaData.Tags](varollo.asepriteimporter.metadata.asepritemetadata#tags)'s JSON data.

```csharp
public string Name { get; internal set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **From**

Firstframe index of the animation corresponding to the tag.
 <br><br>
 Represents property `"from"` on [AsepriteMetaData.Tags](varollo.asepriteimporter.metadata.asepritemetadata#tags)'s JSON data.

```csharp
public Nullable<int> From { get; internal set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **To**

Lastframe index of the animation corresponding to the tag.
 <br><br>
 Represents property `"to"` on [AsepriteMetaData.Tags](varollo.asepriteimporter.metadata.asepritemetadata#tags)'s JSON data.

```csharp
public Nullable<int> To { get; internal set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Direction**

Direction and loop mode of the animation corresponding to the tag.
 <br><br>
 Represents property `"direction"` on [AsepriteMetaData.Tags](varollo.asepriteimporter.metadata.asepritemetadata#tags)'s JSON data.

```csharp
public AsepriteAnimationDirection Direction { get; internal set; }
```

#### Property Value

[AsepriteAnimationDirection](varollo.asepriteimporter.metadata.asepriteanimationdirection)<br>

### **Color**

Color of the tag in Aseprite.
 <br><br>
 Represents property `"color"` on [AsepriteMetaData.Tags](varollo.asepriteimporter.metadata.asepritemetadata#tags)'s JSON data.

```csharp
public Color Color { get; internal set; }
```

#### Property Value

Color<br>

---

[`< Back`](./)
