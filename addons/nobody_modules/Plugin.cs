#if TOOLS
using Godot;

namespace nobody_modules;
public struct InitCharModuleData
{
	public Script ModuleScript { get; set; }
	public Texture2D ModuleIcon { get; set; }
}

[Tool]
public partial class Plugin : EditorPlugin
{
    public override void _EnterTree()
	{

    }

	public override void _ExitTree()
	{

    }
}
#endif
