# Creating a Custom Flax Package (.flaxpackage)

A `.flaxpackage` file is essentially a standard ZIP archive whose extension has been renamed to `.flaxpackage`.

<img src="ProjectTemplate.png">

## Preparing the Project

Before creating the package, make sure your Flax project is clean and only contains the files required to distribute the project template.

Remove generated and temporary files such as:

* Intermediate files
* Cache files
* `.sln` files
* `.csproj` files
* Any other generated files that can be recreated by Flax

The package should contain only the files required to open and use the project.

## Required Files

To be recognized correctly by the Flax Launcher, the archive must contain the following files at its root:

* A `.flaxproj` project file
* An `icon.png` file
* A `meta.xml` file

### icon.png

The `icon.png` file is used by the Flax Launcher as the project thumbnail.

Recommended size:

* 256 × 256 pixels

<img src="icon.png">

### meta.xml

The `meta.xml` file provides the information displayed by the launcher.

Example:

```xml
<Meta>
    <Name>Interaction Manager</Name>
    <Type>ProjectTemplate</Type>
    <Author>Alewinn</Author>
    <Description>Simple interaction system in first person view camera controller using C#, Visual Scripting, UI and outline shader.</Description>
</Meta>
```

Adjust the values to match your own project.

## Archive Structure

The root of the archive should contain at least:

```text
MyProject.flaxproj
icon.png
meta.xml
```

Additional project folders (`Content`, `Source`, etc.) should be located alongside these files as required by the project.

A typical package structure would look like:

```text
MyProject.flaxproj
icon.png
meta.xml

Content/
Source/
```

> Note: You may choose to remove cache and generated data before packaging. The exact content may vary depending on your project.

## Creating the Package

1. Create a ZIP archive containing the project.
2. Verify that the archive root contains the `.flaxproj`, `icon.png`, and `meta.xml` files.
3. Rename the archive extension from `.zip` to `.flaxpackage`.

Example:

```text
MyProject.zip
```

becomes:

```text
MyProject.flaxpackage
```

## Installing the Package

Copy the `.flaxpackage` file into the Flax installation directory:

```text
<Flax Installation>\Launcher\StartupContent
```

For example:

```text
C:\Program Files\Flax\Launcher\StartupContent
```

If the Flax Launcher is already running, restart it.

The package should then appear in the list of available project templates when creating a new project.

## Notes

This procedure is based on experimentation and inspection of existing Flax packages. It is not official documentation and may change in future versions of Flax Engine.

If you discover additional requirements or changes in newer versions of Flax, consider updating this document and sharing your findings with the community.

---

Home => https://github.com/Alewinn-TerizKoming/FlaxVisualScriptingShowcase/tree/main