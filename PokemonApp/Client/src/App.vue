<template>
  <div>
    <h1>PokemonApp</h1>
      <input v-model="pokemonNumber" type="number" placeholder="Enter a Pokemon number" min="1" max="1100">
      <button @click="getPokemon">Get Pokemon</button>
      <div v-if="pokemon">
          <h1>{{ pokemon.name }}</h1>
          <h2>{{ pokemon.number }} </h2>
          <img :src="pokemon.imageUrl" :alt="pokemon.name" />
          <h2>{{ pokemon.type1 }} </h2>
          <h2>{{ pokemon.type2 }} </h2>
          <!--p>{{ pokemon.description }}</p-->
      </div>
  </div>
</template>

<script>import axios from 'axios';

export default {
data() {
  return {
    pokemonNumber: '',
    pokemon: null
  }
},
methods: {
  async getPokemon() {
    if (!this.pokemonNumber) {
      this.pokemon = null;
      return;
    }

    try {
      let response = await axios.get(`api/pokemon/${this.pokemonNumber}`);
      this.pokemon = response.data;
    } catch (error) {
      console.error(error);
      this.pokemon = null;
    }
  }
}
}</script>