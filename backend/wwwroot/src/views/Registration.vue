<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column align-center id="register">
        <h1>Registarion</h1><br>
        <input v-model="login" placeholder="Enter email">
        <input v-model="pass" type="password" placeholder="Enter password">
        <input v-model="conf_pass" type="password" placeholder="Confirm password">
        <v-btn type="submit" class="primary" v-on:click.prevent="message = check(pass, conf_pass)">Submit</v-btn>
        <br><h2>{{message}}</h2>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
  import { Component, Vue } from "vue-property-decorator";
  import axios from "axios";
  export default {
     data() {
        return {
          message: "",
          login: "",
          pass: "",
          conf_pass: ""
        };
    },

    methods: {
      check(login: string ,pass: string, confPass: string) {
        if(pass !== confPass){
          return "Incorrect password!";
        } else {
            return axios.post("api/players", {
              Email: login,
              Password: confPass
            });
        }
      }
    }
  };
</script>
