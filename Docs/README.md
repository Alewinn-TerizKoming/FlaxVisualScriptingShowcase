All theses points are already listed inside the Flax Roadmap (https://trello.com/c/quUfCHWt/315-visual-scripting-roadmap ).
I am only listing the main, most annoying points here, while keeping in mind that the system is already capable of many things.


1- Be very precautionous when duplicating a visual script, especially if it contains functions or parameters ; I don't know if it's a search box design problem (in the order the information is presented regarding the context) or a bug (didn't dig in that yet) but I've encountered cases in which functions/parameters were referencig the original visual script, wich 100% generates exception runtime.

2- Inheriting from a c# OR a c++ script (but I'm mainly using c# right now) is doable, but have limited functionalities, which are : no Event Actions and no overridable methods. If you give your Event Actions types and Overridables method the [Unmanaged] attribute, they will show inside the visual script editor, but A) Event Actions callbacks will raise exception (looks like the type is not resolved runtime) and B) Overridables methods won't be resolved (fail silentely)

3 - Not possible to inherit from another Visual script ; very annoying, mainly because of (1) and (2), this is a real reusability-stoper.

4- Not possible to mutualize nodes groups methods inside a common visual functions asset.

...For the rest, Flax visual scripts have more or less the same limitations than conventional visual scripts (including Unreal's blueprint) ; you'll have to think about recompiling your scripts to be able to use your new functions/variables (normal workflow), in order to have them show inside the editor. Again this point is a "normal" workflow for a lot of decent visual script editors in the market.
