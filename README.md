# Unity Progressive Texture Loading

## Table of Contents
 - [Description](#description)
 - [RoadMap](#roadmap)
 - [Clone](#clone)
 - [Usage](#usage)
    - [Dependencies](#dependencies)
    - [Plugin](#plugin)
    - [In Code](#in-code)
    - [Unit Tests](#unit-tests)

<a id="description"></a>
## Description

<a id="roadmap"></a>
## RoadMap

### OS
- [X] Windows
- [ ] Linux
- [ ] MacOS
- [ ] Android
- [ ] iOS

### Platforms
- [X] OpenGL
- [ ] Direct X (11, 12)
- [ ] Metal
- [ ] Vulkan

### Source Loading Features
- [X] File from disk
- [ ] File from http request
- [ ] File from encode data
- [ ] File from raw data

### Supported Features
- [ ] Dynamic block size
- [ ] Mipmap
- [ ] Gamma / Linear
- [ ] Y Flip

<a id="clone"></a>
## Clone
```sh
$> git clone https://github.com/EricBeetsOfficial/UnityProgressiveTexture.git
```

<a id="usage"></a>
## Usage

<a id="dependencies"></a>
#### Dependencies
Add in the manifest.json

##### UniRX
1. Open the package manager window
2. Select <b>Add package from git URL</b>
3. Input the url below
```
https://github.com/neuecc/UniRx.git?path=Assets/Plugins/UniRx/Scripts
```

<a id="plugin"></a>
#### Plugin

Add in the manifest.json
1. Open the package manager window
2. Select <b>Add package from git URL</b>
3. Input the url below
```
https://github.com/EricBeetsOfficial/UnityProgressiveTexture.git?path=/Packages/ProgressiveTexture
```
or
Add in the manifest.json
1. Open the package manager window
2. Select <b>Add package from disk</b>
3. Select the local folder



<a id="in-code"></a>
#### In Code

See example code in `Scripts/LoadTexture.cs`.

```
_renderer.material.SetTexture("_BaseMap", texture.Load(filePath, _renderer.material, "_BaseMap"));
```
<a id="unit-tests"></a>
#### Unit Tests