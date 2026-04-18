# Plinko - Clase 7
Alumno: Federico Bazán
Fecha: 29-3-26
---
Descripción
Juego estilo Plinko en 2D. Spawneás círculos desde arriba del tablero, rebotan en los pines y caen en zonas de puntaje. Tenés 10 tiros por partida.
---
Controles
- Click izquierdo: Spawnear círculo en la posición del mouse
- A/D: Aplicar fuerza lateral a los círculos
- Space: Dividir el círculo en dos (Split)
---
Ejercicios
Ejercicio 1: Spawn en posición del mouse
- Script: SpawnCircle.cs
- Click izquierdo convierte la posición del mouse a coordenadas del mundo e instancia el prefab
Ejercicio 2: Figuras 2D con Colliders y Prefabs
- 3 formas de pines: círculo, cuadrado, rombo
- Cada uno con su Collider 2D correspondiente
- Prefabs base + Prefab Variants de distintos tamaños
Ejercicio 3: Movimiento lateral con A/D
- Script: CircleController.cs
- Aplica AddForce con ForceMode2D.Impulse hacia izquierda o derecha
- Todos los círculos en pantalla reciben el input simultáneamente
Ejercicio 4: Mecánica nueva con Space (Split)
- Script: CircleController.cs
- El círculo se divide en dos con impulso en direcciones opuestas
- Cada círculo solo puede dividirse una vez con la variable yaHizoSplit
Ejercicio 5: Zonas de puntaje
- Script: ScoreZone.cs
- 5 zonas con valores 10, 20, 50, 20, 10
- Identificadas visualmente con colores (rojo, naranja, amarillo)
- Box Collider 2D con Is Trigger
Ejercicio 6: UI y Game Over
- Script: PlinkoGameManager.cs
- Contador de tiros (X/10) y puntos acumulados
- Panel Game Over al agotar los tiros
- Botón Restart con SceneManager.LoadScene()
---
Bugs resueltos
- Tag no reconocido en runtime: CompareTag() fallaba con clones instanciados, se reemplazó por gameObject.name.Contains()
- Colliders overlapeando: el Size del Box Collider se multiplica por el Scale, solución: Size X = 1 y controlar tamaño solo con Scale
- Doble detección en zonas: se agregó variable fueReclamado en CircleController para que solo una zona pueda reclamar cada círculo
---

# Plinko - Clase 11: Aesthetics Lvl 1 - Parte 2

**Alumno:** Federico Bazán  
**Fecha:** Abril 2026  
**Curso:** Diplomatura en Desarrollo de Videojuegos - UNC

---

## 🎨 Image Rebrand — Estilo Casino Arcade

Ambientación elegida: **Casino Arcade** — inspirado en el Plinko de casino real. Fondo oscuro vinotinto, tablero azul eléctrico con bordes rojos, pines plateados, pelotas doradas con textura, zonas de puntaje en paleta casino y Bloom para efecto de glow.

---

## 🎨 Cambios Visuales

### Paleta de Colores Final
- **Fondo cámara (fuera del tablero):** `#1A0505` (vinotinto oscuro)
- **Tablero (FondoTablero):** `#1A3A6B` (azul oscuro)
- **Paredes y bordes (Tablero):** `#E8002D` (rojo neón) — material `Sprites/Default`
- **Pines:** `#FFFFFF` (blanco) — material `Sprites/Default`
- **Pelotas:** textura PNG de esfera dorada + material `Sprites/Default`
- **Zona 50 (centro):** `#FFD700` (dorado)
- **Zonas 20:** `#1A237E` (azul oscuro)
- **Zonas 10:** `#8B0000` (borgoña)
- **UI (textos):** `#FFD700` (dorado)
- **Botón Restart:** `#E8002D` fondo, `#FFD700` texto

### Fondo de Escena
- Se agregó un GameObject `FondoTablero` (2D Sprite Square) detrás de todos los objetos
- Position Z: 1 para quedar detrás de todo
- Color azul oscuro `#1A3A6B`
- El color de la Main Camera se separó al vinotinto para el área fuera del tablero

### Materiales
- Todos los materiales del proyecto migrados a Shader `Sprites/Default` (compatible con Built-in Render Pipeline)
- Se creó `MaterialPelotas` con textura PNG de esfera y Shader `Sprites/Default`
- La textura se asignó directamente en el campo **Sprite** del Sprite Renderer del Prefab

### Tipografía
- Fuente cambiada a **Cinzel** (Google Fonts) en todos los textos
- Importada como .ttf y convertida con **Window → TextMeshPro → Font Asset Creator**
- Aplicada a: TextoPuntos, TextoCirculos, textos de zonas, texto Game Over, botón Restart

---

## ✨ Post Processing (Bloom + Vignette)

### Configuración
- Paquete **Post Processing** instalado desde **Window → Package Manager → Unity Registry**
- Se agregó componente **Post-process Layer** a la Main Camera con Layer: Everything
- Se creó GameObject vacío `PostProcessing` con componente **Post-process Volume**
  - **Is Global:** ✓
  - **Profile:** nuevo profile creado

### Efectos aplicados
**Bloom:**
- Intensity: 1.5
- Threshold: 0.5
- Efecto visible en paredes rojas y pelotas doradas

**Vignette:**
- Intensity: 0.4
- Color: negro
- Oscurece los bordes de pantalla, refuerza atmósfera de sala de casino

---

## 🎳 Ajuste de Prefab Pelotas

- Se reemplazó el sprite default Circle por una textura PNG de esfera dorada
- Scale ajustado a X: 0.25, Y: 0.25 para coincidir con el tamaño visual correcto
- **Circle Collider 2D** → Radius ajustado a 0.25 para que coincida con el nuevo tamaño visual y los rebotes sean precisos

---

## 🔧 Notas Técnicas

- El proyecto usa **Built-in Render Pipeline** (no URP) — confirmado en Edit → Project Settings → Graphics → Scriptable Render Pipeline: None
- En Built-in, los sprites deben usar Shader `Sprites/Default`
- La textura en objetos con Sprite Renderer se asigna en el campo **Sprite** del componente, no en el material
- El Post Processing de Built-in se instala como paquete separado desde Package Manager

---

**Creado:** Abril 2026  
**Para uso en:** Entrega Clase 11 - Aesthetics Lvl 1 Parte 2