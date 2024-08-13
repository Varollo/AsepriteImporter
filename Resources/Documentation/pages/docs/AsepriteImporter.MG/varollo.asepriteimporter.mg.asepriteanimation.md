[`< Back`](./)

---

# AsepriteAnimation

Namespace: Varollo.AsepriteImporter.MG

Object representing a animation of .

```csharp
public class AsepriteAnimation
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AsepriteAnimation](varollo.asepriteimporter.mg.asepriteanimation)

## Properties

### **Name**

or  corresponding to the animation.

```csharp
public string Name { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **TotalDuration**

Sum of  for all frames in the animation.<br> (and reversed) double original animation duration.

```csharp
public TimeSpan TotalDuration { get; }
```

#### Property Value

[TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan)<br>

### **FrameCount**

Amount of frames present in the animation.

```csharp
public int FrameCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **GetFrameByID(Int32)**

Retrieves a frame in the animation by it's index or "`frameID`".
 <br>Out of bounds "`frameID`" values are wrapped back to `0`.

```csharp
public AsepriteFrame GetFrameByID(int frameID)
```

#### Parameters

`frameID` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Order, starting from `0`, which the frame appears in the animation.

#### Returns

AsepriteFrame<br>
Frame at position ""

### **GetFrameByTime(Double)**

Retrieves the frame in the animation that is suposed to be shown at a elapsed time, in milliseconds.
 <br>Out of bounds "`elapsedMillis`" values are wrapped back to `0`.

```csharp
public AsepriteFrame GetFrameByTime(double elapsedMillis)
```

#### Parameters

`elapsedMillis` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Point in time, in milliseconds, during the animation to retrieve a frame from.

#### Returns

AsepriteFrame<br>
Frame at "`elapsedMillis`" point in time.

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>
This should not occour, if it does, it's a sign my code doesn't work!

---

[`< Back`](./)
