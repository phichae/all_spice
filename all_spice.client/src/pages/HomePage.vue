<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-md-10">
        <section class="row justify-content-center">
          <div class="col-md-3" v-for="r in recipes" :key="r.id">
            <RecipeCard :recipe="r" />
          </div>
        </section>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js'

export default {
  setup() {
    async function getRecipes(){
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error(error, "[GETTING RECIPES]")
      }
    }
    onMounted(() =>{
      getRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
