[`< Back`](./)

---

# AsepriteFrame

Namespace: Varollo.AsepriteImporter

Structure containing data from a frame on a [AsepriteSheet](varollo.asepriteimporter.asepritesheet).

```csharp
public struct AsepriteFrame
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [AsepriteFrame](varollo.asepriteimporter.asepriteframe)

## Properties

### **Name**

Name used to group frames of the same animation, when [AsepriteTagData](varollo.asepriteimporter.metadata.asepritetagdata) is not present.
 <br><br>
 Represents property
 "filename"
 on frame's JSON data.

```csharp
public string Name { get; internal set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SpriteRect**

Rectangular area on the sprite sheet texture corresponding to this frame's pixelboundaries.
 <br><br>
 Represents property "frame"
 on frame's JSON data.

```csharp
public Rectangle SpriteRect { get; internal set; }
```

#### Property Value

Rectangle<br>

### **Rotated**

Represents property "rotated"
 on frame's JSON data.

```csharp
public Nullable<bool> Rotated { get; internal set; }
```

#### Property Value

[Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Trimmed**

Represents property "trimmed"
 on frame's JSON data.

```csharp
public Nullable<bool> Trimmed { get; internal set; }
```

#### Property Value

[Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **SpriteSize**

Bidimensional vector corresponding to the pixelsize of the frame.
 <br><br>
 Represents property "frame"
 on frame's JSON data.

```csharp
public Point SpriteSize { get; internal set; }
```

#### Property Value

Point<br>

### **Duration**

Duration, in milliseconds, the frame should be displayed on the animation.
 <br><br>
 Represents property "frame"
 on frame's JSON data.

```csharp
public TimeSpan Duration { get; internal set; }
```

#### Property Value

[TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan)<br>

---

[`< Back`](./)
