[`< Back`](./)

---

# DrawCounterBase

Namespace: Varollo.AsepriteImporter.MG

Counter used by a [AsepriteAnimator](varollo.asepriteimporter.mg.asepriteanimator). <br>
 Count changes during the  method,
 while ` = true`.

```csharp
public abstract class DrawCounterBase : IAnimationCounter, Microsoft.Xna.Framework.IGameComponent, Microsoft.Xna.Framework.IDrawable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DrawCounterBase](varollo.asepriteimporter.mg.drawcounterbase)<br>
Implements [IAnimationCounter](varollo.asepriteimporter.mg.ianimationcounter), IGameComponent, IDrawable

## Properties

### **DrawOrder**

```csharp
public int DrawOrder { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Visible**

```csharp
public bool Visible { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **DrawCounterBase(Game, Int32)**

Initializes a [DrawTimeCounter](varollo.asepriteimporter.mg.drawtimecounter) as a component of given  instance.

```csharp
public DrawCounterBase(Game game, int drawOrder)
```

#### Parameters

`game` Game<br>
instance.

`drawOrder` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
[optional] Order to count passed time, among other components.

### **DrawCounterBase(GameComponentCollection, Int32)**

Initializes a [DrawTimeCounter](varollo.asepriteimporter.mg.drawtimecounter) and adds it to a

```csharp
public DrawCounterBase(GameComponentCollection components, int drawOrder)
```

#### Parameters

`components` GameComponentCollection<br>
to add counter instance.

`drawOrder` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
[optional] Order to count passed time, among other components.

## Methods

### **GetCount()**

```csharp
public double GetCount()
```

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **SetVisibility(Boolean)**

Enables or disables the counter.

```csharp
public void SetVisibility(bool visible)
```

#### Parameters

`visible` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Visibility state.

### **Initialize()**

```csharp
public void Initialize()
```

### **Draw(GameTime)**

```csharp
public void Draw(GameTime gameTime)
```

#### Parameters

`gameTime` GameTime<br>

### **Count(GameTime)**

Computes [AsepriteAnimation](varollo.asepriteimporter.mg.asepriteanimation) frame count changes.

```csharp
protected abstract double Count(GameTime gameTime)
```

#### Parameters

`gameTime` GameTime<br>
Time information.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Value to add(+) to animation counter.

## Events

### **DrawOrderChanged**

```csharp
public event EventHandler<EventArgs> DrawOrderChanged;
```

### **VisibleChanged**

```csharp
public event EventHandler<EventArgs> VisibleChanged;
```

---

[`< Back`](./)
