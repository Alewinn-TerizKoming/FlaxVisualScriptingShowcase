All of these points are already listed in the Visual Scripting roadmap. I am only highlighting the issues that had the biggest impact on my workflow while working on this showcase project. Overall, the system is already capable of much more than I initially expected.

### 1. Duplicating Visual Script assets

Be careful when duplicating a Visual Script asset, especially if it contains custom functions or parameters.

I have encountered situations where duplicated assets still appeared to reference functions or parameters from the original script. In my case, this resulted in runtime exceptions. I have not investigated deeply enough to determine whether this is a bug or a usability issue related to how references are presented in the editor.

### 2. Inheriting from C# or C++ scripts

Inheriting from a C# (or C++) script is possible, but currently has some limitations.

In particular:

* Event Actions cannot be implemented from Visual Scripts.
* Overridable methods cannot be overridden from Visual Scripts.

If Event Actions or overridable methods are marked with the `[Unmanaged]` attribute, they become visible in the Visual Script editor. However:

* Event Action callbacks raise runtime exceptions (it appears that the type cannot be resolved correctly).
* Overridable methods are displayed but are not actually invoked at runtime.

### 3. No Visual Script inheritance

Visual Scripts cannot currently inherit from other Visual Scripts.

This limitation significantly reduces reusability, especially when combined with the constraints described above. During development, I often found myself duplicating assets instead of extending existing behavior.

### 4. No shared Visual Script function libraries

At the moment, it is not possible to centralize commonly used node groups or helper logic into reusable Visual Script function assets.

As projects grow, this can lead to duplicated logic across multiple graphs.

### General workflow

Most of the remaining limitations are similar to those found in many other visual scripting systems, including Unreal Engine Blueprints.

For example, newly added functions or variables are not immediately available everywhere in the editor until the scripts have been recompiled. This is a fairly standard workflow and not an issue by itself.

One point that initially confused me is that the "Compile Scripts" action is located in the main File menu rather than directly in the Visual Script editor window near the Save button. New users may not immediately discover it.

Despite these limitations, I was able to build the entire gameplay layer of this showcase using a combination of C# and Visual Scripting, which demonstrates that the current system is already practical for small and medium gameplay features.

- [<= root](../) 