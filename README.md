![Alt-текст](https://raw.githubusercontent.com/1dxrpz/DxLib/main/logo_.png)
# DxLib
C# Console game engine

# Getting Started

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
Gameobject(`string name`, `int width`, `int height`)

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



