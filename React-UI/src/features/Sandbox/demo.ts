// inference is preferred, instead of defining type.

let data: number | string = 42; // union type.
data = '43';

console.log(data);

// duck typing.

export interface Duck {
  // must be exported to refer it in DuckItem.tsx
  name: string;
  numLegs: number;
  makeSound: (sound: string) => void;
}

const duck_1: Duck = {
  name: 'duck_1',
  numLegs: 2,
  // :any not allowed in strict mode.
  // if param accepted, must be used in strict mode.
  // param types must match interface contract.
  makeSound: (sound: string) => console.log(sound),
};

const duck_2: Duck = {
  name: 'duck_2',
  numLegs: 2,
  // makeQuack: () => console.log('quack!'),
  makeSound: () => console.log('quack!'),
};

duck_1.makeSound('quick!');
duck_2.makeSound('test'); // Okay but Not Declared In duck_2 func?
// Seems still works, ignores param.

export const ducks = [duck_1, duck_2];
