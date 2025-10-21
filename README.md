# Modular Grid System
## Overview
A modular, data-driven grid system featuring a custom editor tool for layout creation and a runtime snapping system with overlap detection.

## Demo
![Editor Demo](/Medias/EditorDemo.mp4)
Design and export grid layouts directly as reusable data assets.

![Runtime Demo](/Medias/RuntimeDemo.mp4)
Demonstrates runtime loading, snapping behavior, and overlap detection.

## How to Run
1. Clone or download the project.
2. Open in Unity
3. Open `Assets/Scene/01_GridDataEditor.unity` to test the editor tool.
4. Open `Assets/Scene/02_RuntimeDemo.unity` to test runtime loading, snapping, and overlap detection.

## Features
- Grid Editor - Create and edit grid layouts directly in the Unity Editor, then export them as data assets for runtime use.
- Runtime Loading - Load and reconstruct grid layouts dynamically from exported data.
- Snapping System - Drag & drop objects that automatically align to grid cells.
- Overlap Detection - Detect and prevent conflicting placements for objects of varying sizes.

## Tech Used
- Unity ver 2022.3.49f1
- Scriptable object
- Custom editor script
- Personal framework