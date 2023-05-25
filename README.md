# TP Engine
Le projet et les scripts doivent être autant que possible maintenue propres et bien rangés.
Ne pas changer le layer des éléments car ils sont utiles pour l'affichage.

![alt text](TPEngineDemo.gif "Demo")

## 1 - Camera
*Dans un script __CameraControls__*

1. Faire en sorte que l'on puisse faire tourner la camera horizontalement autour du moteur avec les fléches horizontales.
2. Faire en sorte que les fléches verticales permettent de monter ou descendre la camera (dans l'espace du monde).
3. Limiter la translation à maximum 2 mètres vers le haut et vers le bas (de -2 à +2).
4. Faire en sorte que la camera regarde en permanance l'origine du monde grace à la fonction *LookAt()*.

## 2 - Vue en coupe
1. Créer une sphère de 1m de diamètre qu'on appelera *__SeeThroughSphere__*.
2. Lui assigner le material *SeeThroughArea*.
3. Créer une seconde sphère de 1m en enfant de *SeeThroughSphere* qu'on appelera *__StencilMask__*.
4. Lui assigner le material *StencilMask*.
5. Par la méthode de votre choix, faire en sorte que *SeeThroughSphere* grossisse progressivement en 1s de la scale 0 à 1 au start.
6. Faire un prefab à partir de SeeThroughSphere et supprimer l'original de la scène.

*Dans un script __SeeThrough__*

7. Détecter un clique gauche sur la partie arrière du moteur.
8. Spawner une instance du prefab de *SeeThroughSphere* à la position cliquée.
9. Faire en sorte que lors du clique gauche sur la partie arrière, si on a déjà une *SeeThroughSphere* de créée, on détruit cette instance au lieu d'en spawner une nouvelle.

## 3 - Désassemblage
*Dans un script __ScrewManager__*

1. Faire en sorte, à l'aide d'un raycast, qu'un clique gauche sur une vis la désactive (gameObject.SetActive(false)).
2. Lorsque toutes les vis sont désactivées, invoquer un événement publique dont pourront se servir d'autres scripts. Attention à n'appeler l'événement qu'une fois quand l'état change.

*Dans un script __EngineSplitting__*

3. Ajouter une fonction qui écoute l'événement de la question précédente, appelé lorsque toutes les vis sont désactivées.
4. Cette fonction doit séparer le moteur en plusieurs parties progressivement à l'aide d'un lerp.
5. Chercher un moyen de transformer le lerp (linéaire) en un courbe smoothée. Le nom technique est ease-in/out.

## 4 - UI
*Les scripts déjà existants dans le projet ne doivent pas être modifiés.*

1. Créer un bouton ou un toggle qui doit activer ou désactiver le highlight des vis. Pour ce faire, le bouton doit appeler une des fonctions du composant *ScrewHighlight*.
2. Créer un slider qui permette de controller la vitesse du moteur. Pour ce faire, il faut transmettre la valeur du slider au composant *EnginePower* via la fonction *SetPower()*
3. Créer un bouton qui permette de réassembler le moteur et réactiver les vis.

## Rendu
* __Par mail : antoine.collot@live.com__
* Rappeler les membres du groupe.
* Le code source du projet, donc un zip contenant les dossiers *"Assets"* et *"ProjectSettings"* et *"Packages"* de votre projet Unity. Par exemple avec https://wetransfer.com/ ou lien du projet sur github.
* Un gif ou une courte vidéo du projet pour montrer les différentes features en état de marche.
* Eventuelement un readme si il y a des choses que je devrais savoir.
