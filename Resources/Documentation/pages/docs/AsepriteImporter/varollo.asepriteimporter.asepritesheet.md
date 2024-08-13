[`< Back`](./)

---

# AsepriteSheet

Namespace: Varollo.AsepriteImporter

Object representing a Aseprite sprite sheet data.

```csharp
public class AsepriteSheet
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AsepriteSheet](varollo.asepriteimporter.asepritesheet)<br>
Attributes [DefaultMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.defaultmemberattribute)

## Properties

### **Item**

```csharp
public AsepriteFrame Item { get; }
```

#### Property Value

[AsepriteFrame](varollo.asepriteimporter.asepriteframe)<br>

### **Item**

```csharp
public IEnumerable<AsepriteFrame> Item { get; }
```

#### Property Value

[IEnumerable&lt;AsepriteFrame&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **Frames**

Array containing all frames in the sprite sheet.<br><br>
 Represents property
 "frames"
 on frame's JSON data.

```csharp
public AsepriteFrame[] Frames { get; internal set; }
```

#### Property Value

[AsepriteFrame[]](varollo.asepriteimporter.asepriteframe)<br>

### **MetaData**

(optional) Meta data about the sprite sheet.<br><br>
 Represents property
 "meta"
 on frame's JSON data.

```csharp
public Nullable<AsepriteMetaData> MetaData { get; internal set; }
```

#### Property Value

[Nullable&lt;AsepriteMetaData&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **FrameCount**

Amount of frames in the sprite sheet.

```csharp
public int FrameCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **AsepriteSheet()**

```csharp
public AsepriteSheet()
```

## Methods

### **HasAnimation(String)**

Checks whether or not an animation, represented by a `name`, is present in the sprite sheet.

```csharp
public bool HasAnimation(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Key `name` of the animation, corresponding to [AsepriteTagData.Name](varollo.asepriteimporter.metadata.asepritetagdata#name), or [AsepriteFrame.Name](varollo.asepriteimporter.asepriteframe#name)

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` when animation is present, `false` when it isn't.

---

[`< Back`](./)
