<template>
    <div class="col-4 p-3">
        <div class="card">
            <img :src="recipe.img" :alt="recipe.title" class="img-fluid">
            <div class="card-body">
                <h3>
                    {{ recipe.title }}
                </h3>
                <p>
                    {{ recipe.description }}
                </p>
            </div>
        </div>
    </div>

</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: {
        recipe: { required: true, type: Recipe }
    },
    setup(){
        return {}
    }
}
</script>


<style lang="scss" scoped>

    
</style>