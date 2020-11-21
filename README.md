![Alt-текст](https://raw.githubusercontent.com/1dxrpz/DxLib/main/logo_.png)
# DxLib
C# Console game engine

# Getting Started

# Accessing to Theatre
Theatre is a abstract class obligated to manage scenes and debug project
All layers either scenes allign in simple hierarchy:

`.GetOverallInfo()`
```c#
[0000] [DxLibScene] scene1
└ [0000] [DxLibLayer] layer1
  └ [0000] [DxLibGameObject] player
  └ [0001] [DxLibGameObject] wall1
  └ [0002] [DxLibGameObject] wall2
  └ [0003] [DxLibGameObject] door
└ [0001] [DxLibLayer] layer2
  └ [0003] [DxLibGameObject] tree1
  └ [0003] [DxLibGameObject] tree2
  └ [0003] [DxLibGameObject] tree3
└ [0002] [DxLibLayer] layer3
[0001] [DxLibScene] scene2
└ [0000] [DxLibLayer] layer1
└ [0001] [DxLibLayer] layer2
└ [0002] [DxLibLayer] layer3
...
```
# Creating a scene
### Reference 
Scene(`string name`)

```c#
Scene scene1 = new Scene();
var scene2 = new Scene();
...
scene.Render();
scene1.Render();
```
`.Add(Layer)`
```c#
...
Scene s = new Scene();
Layer test = new Layer();
s.Add(test);
...
```
# Creating GameObject
### Reference 
GameObject(`string name`, `int width`, `int height`)

```c#
RenderTypeObject player1 = new GameObject();
GameObject player2 = new GameObject();
var player3 = new GameObject();
...
```

# Creating Layer
### Reference
Layer(`string name`)

```c#
Layer layer1 = new Layer();
var layer2 = new Layer();
...

```
`.Add(RenderTypeObject)`
```c#
...
Layer test = new Layer();
GameObject player = new GameObject();
test.Add(player);
...
```

# Creating label
### Reference
Label()

```c#
Label label1 = new Label();
Label label2 = new Label();
...
layer1.Add(label1);
layer2.Add(label2);
```
`.AddLine(string)`
```c#
...
label1.AddLine("Hello");
label1.AddLine("World");
...
```
`.GetText()`
```c#
...
string test = label1.GetText();
Console.WriteLine(test);
...
```



