# Magical Pong! 🏓✨

[English](#english) | [Español](#español)

---

## English

A 2-player local Pong game built in Unity, made for the **TP04** assignment of *Programación con Motores de Videojuegos I* (Tecnicatura Superior en Desarrollo de Videojuegos, Image Campus).

**🎮 Play it here:** https://kevinlivora.itch.io/magicalpong

### Features

- Physics-based movement for both paddles and the ball (`Rigidbody2D` + `AddForce`)
- Two full scenes: **Main Menu** and **Gameplay**, with a Pause menu inside Gameplay
- Configurable settings via **ScriptableObjects**, persisted across scenes:
  - Paddle speed, height and color for each player
  - Match length: best of 3, 5 or 7 (points to win)
  - Goal timer: automatic point awarded if no goal is scored within a configurable time limit (15–40s)
- Live settings updates: changing a slider affects the paddle in real time during a match
- Ball speeds up on every paddle hit, up to a capped maximum speed
- Paddle turns **black** when it hits the court limits, and a **random color** when it hits the ball
- Pre-round countdown (3-2-1) before the match starts and after every goal, during which paddles are locked
- Score tracking, win condition, and a match-end panel with **Play Again** / **Back to Menu** options
- Court split in half per player using Unity's Physics2D layer collision matrix (paddles collide with an invisible wall, the ball passes through)

### Controls

| Action | Player 1 | Player 2 |
|---|---|---|
| Move | W / A / S / D | Arrow keys |
| Pause | Esc | Esc |

### Built with

- Unity 6000.3.21f1
- TextMeshPro
- Art assets from [Kenney](https://kenney.nl) (CC0)

### Project structure

```
Assets/TP4/
├── Data/          # ScriptableObjects (GameSettings)
├── Prefabs/
├── Scenes/        # Main Menu, Gameplay
└── Scripts/
    ├── Ball/
    ├── Data/
    ├── Editor/    # Editor-only tools, excluded from builds
    ├── Gamplay/   # Goal, MatchManager
    ├── Player/    # Move
    └── UI/
```

### Run it locally

1. Clone this repository.
2. Open the project with **Unity 6000.3.21f1** (or a compatible 6000.3.x LTS version) via Unity Hub.
3. Open `Assets/TP4/Scenes/Main Menu.unity` and press Play.

### Credits

- Developed by **Kevin Livora**
- Course: Programación con Motores de Videojuegos I — Clase 2026
- Teacher: Federico Olivé
- UI and sprite assets: Kenney (kenney.nl)

---

## Español

Un juego de Pong local para 2 jugadores hecho en Unity, para el **TP04** de la materia *Programación con Motores de Videojuegos I* (Tecnicatura Superior en Desarrollo de Videojuegos, Image Campus).

**🎮 Jugalo acá:** https://kevinlivora.itch.io/magicalpong
### Características

- Movimiento con físicas para paddles y pelota (`Rigidbody2D` + `AddForce`)
- Dos escenas completas: **Main Menu** y **Gameplay**, con menú de Pausa dentro de Gameplay
- Configuración mediante **ScriptableObjects**, persistente entre escenas:
  - Velocidad, altura y color de paddle por jugador
  - Duración del partido: mejor de 3, 5 o 7 (puntos para ganar)
  - Timer de gol: se otorga un punto automático si no se convierte un gol dentro de un tiempo configurable (15–40s)
- Los cambios en Settings se aplican en vivo durante la partida
- La pelota acelera con cada impacto contra un paddle, hasta un tope máximo
- El paddle se pone **negro** al chocar los límites de la cancha, y de **color random** al golpear la pelota
- Cuenta regresiva (3-2-1) antes de empezar el partido y después de cada gol, con los paddles bloqueados durante la cuenta
- Sistema de puntaje, condición de victoria, y panel de fin de partido con **Jugar de nuevo** / **Volver al Menú**
- Cancha dividida por mitades usando la matriz de colisión de capas de Physics2D (los paddles chocan contra un muro invisible, la pelota lo atraviesa)

### Controles

| Acción | Jugador 1 | Jugador 2 |
|---|---|---|
| Moverse | W / A / S / D | Flechas |
| Pausa | Esc | Esc |

### Hecho con

- Unity 6000.3.21f1
- TextMeshPro
- Assets de arte de [Kenney](https://kenney.nl) (CC0)

### Estructura del proyecto

```
Assets/TP4/
├── Data/          # ScriptableObjects (GameSettings)
├── Prefabs/
├── Scenes/        # Main Menu, Gameplay
└── Scripts/
    ├── Ball/
    ├── Data/
    ├── Editor/    # Herramientas de Editor, excluidas del build
    ├── Gamplay/   # Goal, MatchManager
    ├── Player/    # Move
    └── UI/
```

### Correrlo localmente

1. Cloná este repositorio.
2. Abrí el proyecto con **Unity 6000.3.21f1** (o una versión LTS 6000.3.x compatible) desde Unity Hub.
3. Abrí `Assets/TP4/Scenes/Main Menu.unity` y dale Play.

### Créditos

- Desarrollado por **Kevin Livora**
- Materia: Programación con Motores de Videojuegos I — Cursada 2026
- Docente: Federico Olivé
- Assets de UI y sprites: Kenney (kenney.nl)
