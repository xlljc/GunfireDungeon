using DsUi;

namespace UI.MapEditorCreateRoom;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class MapEditorCreateRoom : UiBase
{
    /// <summary>
    /// 节点路径: MapEditorCreateRoom.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((MapEditorCreateRoomPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public MapEditorCreateRoom() : base(nameof(MapEditorCreateRoom))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer.RoomNameLabel
    /// </summary>
    public class RoomNameLabel : UiNode<MapEditorCreateRoomPanel, Godot.Label, RoomNameLabel>
    {
        public RoomNameLabel(MapEditorCreateRoomPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override RoomNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer.RoomNameInput
    /// </summary>
    public class RoomNameInput : UiNode<MapEditorCreateRoomPanel, Godot.LineEdit, RoomNameInput>
    {
        public RoomNameInput(MapEditorCreateRoomPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override RoomNameInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<MapEditorCreateRoomPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.RoomNameLabel
        /// </summary>
        public RoomNameLabel L_RoomNameLabel
        {
            get
            {
                if (_L_RoomNameLabel == null) _L_RoomNameLabel = new RoomNameLabel(UiPanel, Instance.GetNode<Godot.Label>("RoomNameLabel"));
                return _L_RoomNameLabel;
            }
        }
        private RoomNameLabel _L_RoomNameLabel;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.RoomNameInput
        /// </summary>
        public RoomNameInput L_RoomNameInput
        {
            get
            {
                if (_L_RoomNameInput == null) _L_RoomNameInput = new RoomNameInput(UiPanel, Instance.GetNode<Godot.LineEdit>("RoomNameInput"));
                return _L_RoomNameInput;
            }
        }
        private RoomNameInput _L_RoomNameInput;

        public HBoxContainer(MapEditorCreateRoomPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2.GroupNameLabel
    /// </summary>
    public class GroupNameLabel : UiNode<MapEditorCreateRoomPanel, Godot.Label, GroupNameLabel>
    {
        public GroupNameLabel(MapEditorCreateRoomPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override GroupNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2.GroupSelect
    /// </summary>
    public class GroupSelect : UiNode<MapEditorCreateRoomPanel, Godot.OptionButton, GroupSelect>
    {
        public GroupSelect(MapEditorCreateRoomPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override GroupSelect Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<MapEditorCreateRoomPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.GroupNameLabel
        /// </summary>
        public GroupNameLabel L_GroupNameLabel
        {
            get
            {
                if (_L_GroupNameLabel == null) _L_GroupNameLabel = new GroupNameLabel(UiPanel, Instance.GetNode<Godot.Label>("GroupNameLabel"));
                return _L_GroupNameLabel;
            }
        }
        private GroupNameLabel _L_GroupNameLabel;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.GroupSelect
        /// </summary>
        public GroupSelect L_GroupSelect
        {
            get
            {
                if (_L_GroupSelect == null) _L_GroupSelect = new GroupSelect(UiPanel, Instance.GetNode<Godot.OptionButton>("GroupSelect"));
                return _L_GroupSelect;
            }
        }
        private GroupSelect _L_GroupSelect;

        public HBoxContainer2(MapEditorCreateRoomPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3.TypeNameLabel
    /// </summary>
    public class TypeNameLabel : UiNode<MapEditorCreateRoomPanel, Godot.Label, TypeNameLabel>
    {
        public TypeNameLabel(MapEditorCreateRoomPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TypeNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3.TypeSelect
    /// </summary>
    public class TypeSelect : UiNode<MapEditorCreateRoomPanel, Godot.OptionButton, TypeSelect>
    {
        public TypeSelect(MapEditorCreateRoomPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override TypeSelect Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3
    /// </summary>
    public class HBoxContainer3 : UiNode<MapEditorCreateRoomPanel, Godot.HBoxContainer, HBoxContainer3>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.TypeNameLabel
        /// </summary>
        public TypeNameLabel L_TypeNameLabel
        {
            get
            {
                if (_L_TypeNameLabel == null) _L_TypeNameLabel = new TypeNameLabel(UiPanel, Instance.GetNode<Godot.Label>("TypeNameLabel"));
                return _L_TypeNameLabel;
            }
        }
        private TypeNameLabel _L_TypeNameLabel;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.TypeSelect
        /// </summary>
        public TypeSelect L_TypeSelect
        {
            get
            {
                if (_L_TypeSelect == null) _L_TypeSelect = new TypeSelect(UiPanel, Instance.GetNode<Godot.OptionButton>("TypeSelect"));
                return _L_TypeSelect;
            }
        }
        private TypeSelect _L_TypeSelect;

        public HBoxContainer3(MapEditorCreateRoomPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4.WeightNameLabel
    /// </summary>
    public class WeightNameLabel : UiNode<MapEditorCreateRoomPanel, Godot.Label, WeightNameLabel>
    {
        public WeightNameLabel(MapEditorCreateRoomPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override WeightNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4.WeightInput
    /// </summary>
    public class WeightInput : UiNode<MapEditorCreateRoomPanel, Godot.SpinBox, WeightInput>
    {
        public WeightInput(MapEditorCreateRoomPanel uiPanel, Godot.SpinBox node) : base(uiPanel, node) {  }
        public override WeightInput Clone() => new (UiPanel, (Godot.SpinBox)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4
    /// </summary>
    public class HBoxContainer4 : UiNode<MapEditorCreateRoomPanel, Godot.HBoxContainer, HBoxContainer4>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.WeightNameLabel
        /// </summary>
        public WeightNameLabel L_WeightNameLabel
        {
            get
            {
                if (_L_WeightNameLabel == null) _L_WeightNameLabel = new WeightNameLabel(UiPanel, Instance.GetNode<Godot.Label>("WeightNameLabel"));
                return _L_WeightNameLabel;
            }
        }
        private WeightNameLabel _L_WeightNameLabel;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.WeightInput
        /// </summary>
        public WeightInput L_WeightInput
        {
            get
            {
                if (_L_WeightInput == null) _L_WeightInput = new WeightInput(UiPanel, Instance.GetNode<Godot.SpinBox>("WeightInput"));
                return _L_WeightInput;
            }
        }
        private WeightInput _L_WeightInput;

        public HBoxContainer4(MapEditorCreateRoomPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5.RemarkNameLabel
    /// </summary>
    public class RemarkNameLabel : UiNode<MapEditorCreateRoomPanel, Godot.Label, RemarkNameLabel>
    {
        public RemarkNameLabel(MapEditorCreateRoomPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override RemarkNameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5.RemarkInput
    /// </summary>
    public class RemarkInput : UiNode<MapEditorCreateRoomPanel, Godot.TextEdit, RemarkInput>
    {
        public RemarkInput(MapEditorCreateRoomPanel uiPanel, Godot.TextEdit node) : base(uiPanel, node) {  }
        public override RemarkInput Clone() => new (UiPanel, (Godot.TextEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5
    /// </summary>
    public class HBoxContainer5 : UiNode<MapEditorCreateRoomPanel, Godot.HBoxContainer, HBoxContainer5>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.RemarkNameLabel
        /// </summary>
        public RemarkNameLabel L_RemarkNameLabel
        {
            get
            {
                if (_L_RemarkNameLabel == null) _L_RemarkNameLabel = new RemarkNameLabel(UiPanel, Instance.GetNode<Godot.Label>("RemarkNameLabel"));
                return _L_RemarkNameLabel;
            }
        }
        private RemarkNameLabel _L_RemarkNameLabel;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.RemarkInput
        /// </summary>
        public RemarkInput L_RemarkInput
        {
            get
            {
                if (_L_RemarkInput == null) _L_RemarkInput = new RemarkInput(UiPanel, Instance.GetNode<Godot.TextEdit>("RemarkInput"));
                return _L_RemarkInput;
            }
        }
        private RemarkInput _L_RemarkInput;

        public HBoxContainer5(MapEditorCreateRoomPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer5 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<MapEditorCreateRoomPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer _L_HBoxContainer;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.HBoxContainer2
        /// </summary>
        public HBoxContainer2 L_HBoxContainer2
        {
            get
            {
                if (_L_HBoxContainer2 == null) _L_HBoxContainer2 = new HBoxContainer2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer2"));
                return _L_HBoxContainer2;
            }
        }
        private HBoxContainer2 _L_HBoxContainer2;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.HBoxContainer3
        /// </summary>
        public HBoxContainer3 L_HBoxContainer3
        {
            get
            {
                if (_L_HBoxContainer3 == null) _L_HBoxContainer3 = new HBoxContainer3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer3"));
                return _L_HBoxContainer3;
            }
        }
        private HBoxContainer3 _L_HBoxContainer3;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.HBoxContainer4
        /// </summary>
        public HBoxContainer4 L_HBoxContainer4
        {
            get
            {
                if (_L_HBoxContainer4 == null) _L_HBoxContainer4 = new HBoxContainer4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer4"));
                return _L_HBoxContainer4;
            }
        }
        private HBoxContainer4 _L_HBoxContainer4;

        /// <summary>
        /// 节点路径: MapEditorCreateRoom.MarginContainer.HBoxContainer5
        /// </summary>
        public HBoxContainer5 L_HBoxContainer5
        {
            get
            {
                if (_L_HBoxContainer5 == null) _L_HBoxContainer5 = new HBoxContainer5(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer5"));
                return _L_HBoxContainer5;
            }
        }
        private HBoxContainer5 _L_HBoxContainer5;

        public VBoxContainer(MapEditorCreateRoomPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorCreateRoom.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<MapEditorCreateRoomPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorCreateRoom.VBoxContainer
        /// </summary>
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public MarginContainer(MapEditorCreateRoomPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer.RoomNameLabel
    /// </summary>
    public RoomNameLabel S_RoomNameLabel => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer.RoomNameInput
    /// </summary>
    public RoomNameInput S_RoomNameInput => L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomNameInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_MarginContainer.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2.GroupNameLabel
    /// </summary>
    public GroupNameLabel S_GroupNameLabel => L_MarginContainer.L_VBoxContainer.L_HBoxContainer2.L_GroupNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2.GroupSelect
    /// </summary>
    public GroupSelect S_GroupSelect => L_MarginContainer.L_VBoxContainer.L_HBoxContainer2.L_GroupSelect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer2
    /// </summary>
    public HBoxContainer2 S_HBoxContainer2 => L_MarginContainer.L_VBoxContainer.L_HBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3.TypeNameLabel
    /// </summary>
    public TypeNameLabel S_TypeNameLabel => L_MarginContainer.L_VBoxContainer.L_HBoxContainer3.L_TypeNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3.TypeSelect
    /// </summary>
    public TypeSelect S_TypeSelect => L_MarginContainer.L_VBoxContainer.L_HBoxContainer3.L_TypeSelect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer3
    /// </summary>
    public HBoxContainer3 S_HBoxContainer3 => L_MarginContainer.L_VBoxContainer.L_HBoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4.WeightNameLabel
    /// </summary>
    public WeightNameLabel S_WeightNameLabel => L_MarginContainer.L_VBoxContainer.L_HBoxContainer4.L_WeightNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4.WeightInput
    /// </summary>
    public WeightInput S_WeightInput => L_MarginContainer.L_VBoxContainer.L_HBoxContainer4.L_WeightInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer4
    /// </summary>
    public HBoxContainer4 S_HBoxContainer4 => L_MarginContainer.L_VBoxContainer.L_HBoxContainer4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5.RemarkNameLabel
    /// </summary>
    public RemarkNameLabel S_RemarkNameLabel => L_MarginContainer.L_VBoxContainer.L_HBoxContainer5.L_RemarkNameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5.RemarkInput
    /// </summary>
    public RemarkInput S_RemarkInput => L_MarginContainer.L_VBoxContainer.L_HBoxContainer5.L_RemarkInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer.HBoxContainer5
    /// </summary>
    public HBoxContainer5 S_HBoxContainer5 => L_MarginContainer.L_VBoxContainer.L_HBoxContainer5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorCreateRoom.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
