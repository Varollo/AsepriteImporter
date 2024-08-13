[`< Back`](./)

---

# DrawFrameCounter

Namespace: Varollo.AsepriteImporter.MG

Counter used by a [AsepriteAnimator](varollo.asepriteimporter.mg.asepriteanimator). <br>
 Count changes during the  method,
 Counts Draw calls.

```csharp
public class DrawFrameCounter : DrawCounterBase, IAnimationCounter, Microsoft.Xna.Framework.IGameComponent, Microsoft.Xna.Framework.IDrawable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DrawCounterBase](varollo.asepriteimporter.mg.drawcounterbase) → [DrawFrameCounter](varollo.asepriteimporter.mg.drawframecounter)<br>
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
public bool Visible { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **DrawFrameCounter(Game, Int32)**

```csharp
public DrawFrameCounter(Game game, int drawOrder)
```

#### Parameters

`game` Game<br>

`drawOrder` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **DrawFrameCounter(GameComponentCollection, Int32)**

```csharp
public DrawFrameCounter(GameComponentCollection components, int drawOrder)
```

#### Parameters

`components` GameComponentCollection<br>

`drawOrder` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **Count(GameTime)**

```csharp
protected double Count(GameTime gameTime)
```

#### Parameters

`gameTime` GameTime<br>

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

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
