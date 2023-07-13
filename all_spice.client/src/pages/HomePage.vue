<template>
  <div class="container-fluid">
    <div v-for="r in recipes" :key="r.id">
      <RecipeCard :recipes="r" />
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
