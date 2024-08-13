<img style="align: center;" src="../imgs/title.png"/>
<table align="center">
  <th><a href="../index.md">   Home     </a></th>
  <th><a href="aseprite.md">   Aseprite </a></th>
  <th><a href="monogame.md">   Core     </a></th>
  <th><a style="color: gray;"> MonoGame </a></th>
</table>

----------------------------------------

# MonoGame Module

This section explains the installation process and use of the **MonoGame** module of the Library.

## 1. Installation Process

TODO

## 2. Animating with the `AsepriteAnimator`

The `AsepriteAnimator` class can be used to handle *animations* of a *sprite sheet*.

To create an **instance**, it requires loaded **AsepriteSheet** (more about it on the ["Core" page](./core.md#2-loading-the-sprite-sheet-data)), and a **counter** object.

### 2.1 The Counter Object

To allow a more flexible implementation of counting up the *frames*, and not tie it to **MonoGame's** `IGameComponent` system, the **animator** uses an instance of a object that implements the `IAnimationCounter` *interface*.

### 2.2 Built-in Counters

You can skip implementing the `IAnimationCounter` *interface* by using one of two(2) **built-in counters**. Both work with **MonoGame's** `IGameComponent` system, and implement the `IDrawable` interface, therefore, you must provide either the main `Game` instance, or its `GameComponentCollection` reference.

Both set their `DrawOrder` to `int.MinValue`, so they run before any other *drawable component*, but if needed, you can provide a custom `drawOrder`, as an optional *parameter*.

- [DrawTimeCounter](./docs/AsepriteImporter.MG/varollo.asepriteimporter.mg.drawtimecounter.md): counts the amount of **milliseconds** passed since last frame.
- [DrawFrameCounter](./docs/AsepriteImporter.MG/varollo.asepriteimporter.mg.drawframecounter.md): counts up (+1) for every time its `Draw(GameTime)` method is called.

> **&#9432; QUICK INFO** </br>
> Generally, you want to use the `DrawTimeCounter`, since **Aseprite** stores frame times as milliseconds.

**EXAMPLE:**

```cs
private IAnimationCounter GetCounter(Game game)
{
    return new DrawTimeCounter(game);
}
```

### 2.3 Implementing a Custom Counter

The only required *method* in the `IAnimationCounter` interface, is the `GetCount()` method, whose purpose is to provide the current **count** of the counter. The way your **counter** *actually* increases, is up to you.

**EXAMPLE:**

```cs
public class MyCounter : IAnimationCounter
{
    private double _count;

    public double GetCount()
    {
        // Counts up every time GetCount() is requested
        _count += 1;        
        return _count;
    }
}
```

## 3. Drawing the Frame

The **animator** itself doesn't *Draw* the *texture*, rather, you call the `GetFrame(string)` method, passing in the `name` of the animation, which returns a `Rectangle` representing the area on the *texture* corresponding to the current frame.

Since the **animator** uses a single **counter**, it doesn't matter how many times you call `GetFrame(string)` repeatedly, the *frame* will wrap based on the total *duration* of the *animation*.

**EXAMPLE:**

```cs
private void Draw(GameTime gameTime)
{
    Rectangle playerFrame = animator.GetFrame("player.idle");
    Rectangle monsterFrame = animator.GetFrame("monster.idle");

    spriteBatch.Begin();
    spriteBatch.Draw(texture, position, playerFrame, Color.White);
    spriteBatch.Draw(texture, position, monsterFrame, Color.White);
    spriteBatch.End();
}
```

## 4. Full Documentation

To go more in depth about all the **MonoGame** *library*'s *methods* and *classes*, you may find the **full documentation** [here](./docs/AsepriteImporter.MG/index.md).

----------------------------------------

<p style="text-align: center; font-size: 13px; color: gray;">
    By <a href="https://varollo.github.io/"><i>Varollo</i></a>.
</p>