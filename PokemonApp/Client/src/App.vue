<template>
  <div class="container">
    <h1>PokemonApp</h1>
    <input class="form-control my-2" v-model="inputValue" type="number" placeholder="Enter a Pokemon number"
      :min="minValue" :max="maxValue" @input="checkInput">
    <button class="btn btn-primary mb-2" :disabled="isDisabled" @click="getPokemon">Gotta catch 'em all!</button>
    <div class="alert alert-warning" role="alert" v-if="notification">{{ notification }}</div>
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

<script>
import axios from 'axios';

export default {
  data() {
    return {
      inputValue: null,
      minValue: 1,
      maxValue: 1010,
      notification: null,
      pokemon: null
    }
  },
  computed: {
    isDisabled() {
      return this.inputValue === null || this.inputValue < this.minValue || this.inputValue > this.maxValue
    }
  },
  methods: {
    checkInput() {
      if (this.inputValue < this.minValue || this.inputValue > this.maxValue) {
        this.notification = `Input value must be between ${this.minValue} and ${this.maxValue}`
      } else {
        this.notification = null
      }
    },

    async getPokemon() {
      if (!this.inputValue) {
        this.pokemon = null;
        return;
      }
      try {
        let response = await axios.get(`api/pokemon/${this.inputValue}`);
        this.pokemon = response.data;
      } catch (error) {
        console.error(error);
        this.pokemon = null;
      }
    }
  }
}
</script>