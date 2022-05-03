# Creatures

Objectif: Concevoir un algorithme génétique pour faire évoluer une créature dans un environement.

Nous avons choisit de créer une créature volante dont l'ojectif est d'atteindre une falaise en hauteur.
La créature doit donc être capable d'avancer suffisament, et de monter suffisament haut en allant le plus droit possible.
A chaque génération, la créature va varier la taille de ses ailes, de sa queue et de son poids pour améliorer sa qualité de vol.

![image](https://user-images.githubusercontent.com/99044194/166423386-63628b31-2541-4398-b7b9-8c5fd33ca38c.png)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Le projet a été réaliser avec le moteur graphique Unity et les scripts en langages C#.

Pour lancé le projet, il suffit de lancé la simulation directement depuis unity

![image](https://user-images.githubusercontent.com/99044194/166417196-35a9158e-dfcd-4200-81ed-d9f2806f47a4.png)

Le projet se trouve dans la scene mainScene du dossier Scene.

Les scripts se trouvent dans le dossier scrpit. 

Il n'y a normalement rien de particulier a faire pour que le projet fonctionne. Il suffit de récupérer le dépôt et de la lancer avec Unity.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Organisation du code 

Le script Creature gère la fabrication du prefab, ainsi que la physique et les forces qui s'exercent sur la créature. 

Le scripte Generation fabrique et lance 200 créatures avec des gènes différents.

Le script Evolution lance les générations de créatures jusqu'a ce que le score moyen d'un génération atteigne 80.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Le projet

L'algorithme

Nous avons créer notre propre algorithme d'évolution qui optimise la créature au fil des générations. 
Le principe:

![image](https://user-images.githubusercontent.com/99044194/166421807-2b2b1cad-3866-4015-a20e-4eb84994ea30.png)

L'algorithme lance une première génération de créatures.

Les 60 meilleures créatures sont sélectioonner pour former la géneration parent.

Chaque nouvelle créature est créer à partir de gènes aléatoire de la géneration parent.

Ce processus est réitéré jusqu'a ce qu'une géneration atteigne un score moyen de 80.

Le score est calculé selon 3 critères:
  - la réussite = +50pts
  - la rapidité = 30pts
  - l'esthetisme = 20 pts

La créature

![image](https://user-images.githubusercontent.com/99044194/166421927-b09a76bf-a257-414f-bff8-8545c7edd16c.png)
![image](https://user-images.githubusercontent.com/99044194/166422101-4275bab6-e754-4886-90ac-ddf324ab5112.png)

Nous avons conçut un prefab de notre créature. 

Et nous avons créer une physique à notre créature, la gravité lui est appliquer en permanace. La force de gravité varie en fonction du poids.

Les ailes permettent de monter, et d'avancer légèrement. Une force latérale et également appliquée. La force varie en fonction de la longeur de l'aile.

Quand à la queue, elle permet d'avancer et de monter. C'est également sa longeur qui fait varier la force.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Les résultats 

Après de nombreuses simulations, nous avons observé qu'il faut en géneral environ 15 génerations pour atteindre l'objectif.

![Image3](https://user-images.githubusercontent.com/99044194/166424257-8e644ad8-3516-4fa2-b823-e60fde8726f3.png)

Nous avons également lancer une simulation sans objectif pour voir si il était possible d'atteindre 100 ou si le score se stabilisé. 

Nous avons effectivement pu observer une stabilisation autour de 91.

![Image1](https://user-images.githubusercontent.com/99044194/166424220-1fd482eb-ef45-4a74-8289-3536c4e5c60a.png)

