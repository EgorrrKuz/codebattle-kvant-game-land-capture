<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column align-center id="register">
        <h1>Registarion</h1><br>
        <input v-model="login" placeholder="Enter email">
        <input v-model="pass" type="password" placeholder="Enter password">
        <input v-model="conf_pass" type="password" placeholder="Confirm password">
        <v-btn type="submit" class="primary" v-on:click.prevent="register(login, pass, conf_pass)">Submit</v-btn>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
  import PlayerController from "@/Controllers/playerController";

  export default {
     data() {
        return {
          login: "",
          pass: "",
          conf_pass: ""
        };
    },

    methods: {
      register(login: string, pass: string, confPass: string): any {
        if(pass !== confPass) {
          //alert("Incorrect password");
          alert(PlayerController.GetUser(login));
        } else if(pass.length < 8) {
          alert("Your password is less than 8 symbols");
        } else if(PlayerController.GetUser(login) == login) {
          alert("You did registered");
        } else {
          alert("You registered");

          return PlayerController.CreateUser(login, pass);
        }
      }
    }
  };
</script>
