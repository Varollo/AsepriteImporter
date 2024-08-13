<img style="align: center;" src="../imgs/title.png"/>
<table align="center">
  <th><a href="../index.md">   Home     </a></th>
  <th><a href="aseprite.md">   Aseprite </a></th>
  <th><a style="color: gray;"> Core     </a></th>
  <th><a href="monogame.md">   MonoGame </a></th>
</table>

----------------------------------------

# Core Library

This section explains the installation process and use of the **Core** module of the Library.

## 1. Installing the `.dll`

Firstly, download the `AsepriteImporter.dll` file, on the [Releases](https://github.com/Varollo/aseprite-importer/releases) page, from the latest version.

The installation process varies depending on your *framework* of choice.

### 1.1 Installing the Core `.dll` on a **.NET** project

There are a few ways to add a reference to the `.dll` *assembly*, here are some options:

**Through the Project File (`.csproj`):** 
  1. Edit your **project file**;
  2. Include the following *XML* **markup**:
```xml
<ItemGroup>
  <Reference Include="AsepriteImporter">
    <HintPath> {PATH_TO_DLL}\AsepriteImporter.dll </HintPath>
  </Reference>
</ItemGroup>
```

<br/>

**Through _Visual Studio_:**
  1. *Right-Click* the **Project** on the **Solution Explorer**;
  2. Choose the *command* **Add > Project Reference**;
  3. *Click* **Browse** on the *bottom-right* of the *Reference Manager Window*;
  4. Locate the *directory* with the `AsepriteImporter.dll` file;
  5. *Select* the *dll* file and *click* **Add**;
  6. *Check* the **box** on the side of the added *reference*.

## 2. Loading the *Sprite Sheet Data*

First, don't forget to include the code bellow at the top your file:

```cs
using Varollo.AsepriteImporter;
```

When you want to load a *sprite sheet data* file, call the method `LoadJsonData`, on the `AsepriteDataLoader` static class, passing in the `path` to the `.json` file, like this:

```cs
const string PATH = "root/directory/data.json";

private AsepriteSheet LoadMyData()
{
    AsepriteSheet sheetData = AsepriteDataLoader.LoadJsonData(PATH);

    return sheetData;
}
```

This will load the file using `System.IO` and automatically parse it into a `AsepriteSheet` object using the [Json.Net](https://www.newtonsoft.com/json) library, by [Newtonsoft](https://www.newtonsoft.com/).

You can also opt to **parse** the *data* through a string containing the *json*, using the `ParseJsonData` method:

```cs
private AsepriteSheet LoadMyData()
{
    string json = LoadJsonInternally();

    AsepriteSheet sheetData = AsepriteDataLoader.ParseJsonData(json);

    return sheetData;
}
```

## 3. Reading the *Frames* of a *Sprite Sheet Data*

You can read the frame data deserialized into a `AsepriteSheet` object in three different ways:

### 3.1 Accessing the `Frames` Array

One way to access all frames in the *sprite sheet*, is through the *property* `Frames`, that stores in an *Array* the data for every **frame** in the sheet.

**EXAMPLE:**

```cs
private void LogFrameNames(AsepriteSheet sheet)
{
  foreach(AsepriteFrame frame in sheet.Frames)
  {
    System.Console.WriteLine(frame.Name);
  }
}
```

> [Documentation Page.](./docs/core_docs/varollo.asepriteimporter.asepritesheet.md#frames)

### 3.2 Using the *frame* `Index`

When you need to access a frame knowing its index in the *sheet* **Frame** *array*, the easiest way to get its information is through the `AsepriteSheet` *indexer*, passing in the **frame index** as a parameter.

**EXAMPLE:**

```cs
private void LogFirstFrameName(AsepriteSheet sheet)
{
  AsepriteFrame frame = sheet[0];
  System.Console.WriteLine(frame.Name);
}
```

> [Documentation Page.](./docs/core_docs/varollo.asepriteimporter.asepritesheet.md#item)

### 3.3 Getting the *Animation Frames* by `Name`

To filter the *frames* of a specific *animation*, you can also use the `AsepriteSheet` *indexer*, this time, passing the `Name` of the *animation*. 

You can find more information about grouping *frames* of the same *animation* [here](../../../README.md#3-separating-animations-with-a-filename-format).

**EXAMPLE:**

```cs
private void LogFrameNamesOfAnimation(AsepriteSheet sheet, string animationName)
{
  foreach(AsepriteFrame frame in sheet[animationName])
  {
    System.Console.WriteLine(frame.Name);
  }
}
```

> [Documentation Page.](./docs/core_docs/varollo.asepriteimporter.asepritesheet.md#item-1)

## 4. Checking if the *Sprite Sheet* includes an *Animation*

To check if the *sprite sheet* contains an *animation* of a certain *name*, the simplest way is through the `AsepriteSheet` method `HasAnimation(string)`.

**EXAMPLE:**

```cs
private void LogTrueIfAnimationIsPresent(AsepriteSheet sheet, string animationName)
{
  System.Console.WriteLine(sheet.HasAnimation(animationName));
}
```

> [Documentation Page.](./docs/core_docs/varollo.asepriteimporter.asepritesheet.md#hasanimationstring)

## 5. Accessing the *Metadata*

If your `.json` file contains *Aseprite* generated **Metadata**, and you need to retrieve any information from it, you can do so through the `AsepriteSheet` property `MetaData`.

More information about configuring the generated **Metadata** on *Aseprite* can be found on the [project's README file](../../../README.md#4-using-the-tag-metadata).

**EXAMPLE:**

```cs
private void LogAsepriteVersion(AsepriteSheet sheet)
{
  System.Console.WriteLine(sheet.MetaData ?? "No metadata present...");
}
```

> [Documentation Page.](./docs/core_docs/varollo.asepriteimporter.asepritesheet.md#metadata)

## 6. Full Documentation

To go more in depth about all the **Core** *library*'s *methods* and *classes*, you may find the **full documentation** [here](./docs/AsepriteImporter/index.md).

----------------------------------------

<p style="text-align: center; font-size: 13px; color: gray;">
    By <a href="https://varollo.github.io/"><i>Varollo</i></a>.
</p>