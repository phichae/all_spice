<template>
        <div class="card p-3 recipe-card my-3">
            <img :src="recipe.img" :alt="recipe.title" class="img-fluid recipe-img">
            <div class="card-body">
                <h3>
                    {{ recipe.title }}
                </h3>
                <span class="align-bottom">
                    {{ recipe.category }}
                </span>
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
    .recipe-card{
        height: 70vh;
    }

    .recipe-img{
        height: 50vh;
        width: 100%;
        object-fit: cover;
        object-position: center;
    }
    
</style>