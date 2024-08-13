[`< Back`](./)

---

# AsepriteAnimator

Namespace: Varollo.AsepriteImporter.MG

Handles all [AsepriteAnimation](varollo.asepriteimporter.mg.asepriteanimation) on a

```csharp
public class AsepriteAnimator
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AsepriteAnimator](varollo.asepriteimporter.mg.asepriteanimator)

## Constructors

### **AsepriteAnimator(IAnimationCounter, AsepriteSheet)**

Initializes a [AsepriteAnimator](varollo.asepriteimporter.mg.asepriteanimator) for a  using a [IAnimationCounter](varollo.asepriteimporter.mg.ianimationcounter)

```csharp
public AsepriteAnimator(IAnimationCounter counter, AsepriteSheet sheet)
```

#### Parameters

`counter` [IAnimationCounter](varollo.asepriteimporter.mg.ianimationcounter)<br>
Object responsible for increasing animation frame. Such as [DrawTimeCounter](varollo.asepriteimporter.mg.drawtimecounter).

`sheet` AsepriteSheet<br>
Sprite sheet deserialized using

## Methods

### **GetAnimation(String)**

Retrieves an animation by  or .

```csharp
public AsepriteAnimation GetAnimation(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name or tag key for the animation.

#### Returns

[AsepriteAnimation](varollo.asepriteimporter.mg.asepriteanimation)<br>
Found animation of given name key.

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Thrown when no animation is found with that name key.

### **GetFrame(String)**

Retrieves the current frame () for an animation using the  or .

```csharp
public Rectangle GetFrame(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name or tag key for the animation.

#### Returns

Rectangle<br>
Rectangle corresponding to the  of the current frame of animation.

---

[`< Back`](./)
